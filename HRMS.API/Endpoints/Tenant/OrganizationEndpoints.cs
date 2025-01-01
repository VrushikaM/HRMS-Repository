using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.Tenant.Organization.OrganizationRequestDtos;
using HRMS.Dtos.Tenant.Organization.OrganizationResponseDtos;
using HRMS.Utility.Helpers.Enums;
using HRMS.Utility.Helpers.Handlers;
using HRMS.Utility.Helpers.LogHelpers.Interface;
using HRMS.Utility.Validators.Tenant.Organization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HRMS.API.Endpoints.Tenant
{
    public static class OrganizationEndpoints
    {
        public static void MapOrganizationEndpoints(this IEndpointRouteBuilder app)
        {

            app.MapGet("/HRMS/GetOrganizations", async (IOrganizationService service, IOrganizationLogger logger) =>
            {
                logger.LogInformation("Fetching all organizations.");

                var organizations = await service.GetOrganizations();
                if (organizations != null && organizations.Any())
                {
                    var response = ResponseHelper<List<OrganizationReadResponseDto>>.Success("Organizations Retrieved Successfully", organizations.ToList());
                    logger.LogInformation("Successfully retrieved {Count} organizations.", organizations.Count());
                    return Results.Ok(response.ToDictionary());
                }

                logger.LogWarning("No organizations found.");
                var errorResponse = ResponseHelper<IEnumerable<OrganizationReadResponseDto>>.Error("No Organizations Found");
                return Results.NotFound(errorResponse.ToDictionary());
            });

            app.MapGet("/HRMS/Organization/{id}", async (IOrganizationService service, int id, IOrganizationLogger logger) =>
            {
                logger.LogInformation("Fetching organization with ID {OrganizationId}.", id);

                var validator = new OrganizationReadRequestValidator();
                var organizationRequestDto = new OrganizationReadRequestDto { OrganizationID = id };

                var validationResult = validator.Validate(organizationRequestDto);
                if (!validationResult.IsValid)
                {
                    var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    logger.LogWarning("Validation failed for organization with ID {OrganizationId}: {Errors}", id, string.Join(", ", errorMessages));
                    return Results.BadRequest(
                        ResponseHelper<List<string>>.Error(
                            message: "Validation Failed",
                            errors: errorMessages,
                            statusCode: StatusCodeEnum.BAD_REQUEST
                        ).ToDictionary()
                    );
                }
                try
                {
                    var organization = await service.GetOrganizationById(id);
                    if (organization == null)
                    {
                        logger.LogWarning("Organization with ID {OrganizationId} not found.", id);
                        return Results.NotFound(
                            ResponseHelper<string>.Error(
                                message: "Organization Not Found",
                                statusCode: StatusCodeEnum.NOT_FOUND
                            ).ToDictionary()
                        );
                    }

                    logger.LogInformation("Successfully retrieved organization with ID {OrganizationId}.", id);
                    return Results.Ok(
                        ResponseHelper<OrganizationReadResponseDto>.Success(
                            message: "Organization Retrieved Successfully",
                            data: organization
                        ).ToDictionary()
                    );
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An unexpected error occurred while retrieving the organization with ID {OrganizationId}.", id);
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            });

            app.MapPost("/CreateOrganization", async (OrganizationCreateRequestDto dto, IOrganizationService _organizationService, IOrganizationLogger logger) =>
            {
                logger.LogInformation("Creating new organization with data: {OrganizationData}", dto);

                var validator = new OrganizationCreateRequestValidator();
                var validationResult = validator.Validate(dto);

                if (!validationResult.IsValid)
                {
                    var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    logger.LogWarning("Validation failed for creating organization: {Errors}", string.Join(", ", errorMessages));
                    return Results.BadRequest(
                        ResponseHelper<List<string>>.Error(
                            message: "Validation Failed",
                            errors: errorMessages,
                            statusCode: StatusCodeEnum.BAD_REQUEST
                        ).ToDictionary()
                    );
                }
                try
                {
                    var newOrganization = await _organizationService.CreateOrganization(dto);
                    logger.LogInformation("Successfully created organization with ID {OrganizationId}.", newOrganization.OrganizationID);
                    return Results.Ok(
                        ResponseHelper<OrganizationCreateResponseDto>.Success(
                            message: "Organization Created Successfully",
                            data: newOrganization
                        ).ToDictionary()
                    );
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An unexpected error occurred while creating the organization.");
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Creating the Organization.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            });

            app.MapPut("/HRMS/UpdateOrganization", async (IOrganizationService service, [FromBody] OrganizationUpdateRequestDto dto, IOrganizationLogger logger) =>
            {
                logger.LogInformation("Updating organization with ID {OrganizationId}.", dto.OrganizationID);

                var validator = new OrganizationUpdateRequestValidator();
                var validationResult = validator.Validate(dto);

                if (!validationResult.IsValid)
                {
                    var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    logger.LogWarning("Validation failed for updating organization with ID {OrganizationId}: {Errors}", dto.OrganizationID, string.Join(", ", errorMessages));
                    return Results.BadRequest(
                       ResponseHelper<List<string>>.Error(
                           message: "Validation Failed",
                           errors: errorMessages,
                           statusCode: StatusCodeEnum.BAD_REQUEST
                       ).ToDictionary()
                   );
                }
                try
                {
                    var updatedOrganization = await service.UpdateOrganization(dto);
                    if (updatedOrganization == null)
                    {
                        logger.LogWarning("Organization with ID {OrganizationId} not found for update.", dto.OrganizationID);
                        return Results.NotFound(
                           ResponseHelper<string>.Error(
                               message: "Organization Not Found",
                               statusCode: StatusCodeEnum.NOT_FOUND
                           ).ToDictionary()
                       );
                    }

                    logger.LogInformation("Successfully updated organization with ID {OrganizationId}.", dto.OrganizationID);
                    return Results.Ok(
                        ResponseHelper<OrganizationUpdateResponseDto>.Success(
                            message: "Organization Updated Successfully",
                            data: updatedOrganization
                        ).ToDictionary()
                    );
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An unexpected error occurred while updating the organization with ID {OrganizationId}.", dto.OrganizationID);
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Updating the Organization.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            });

            app.MapDelete("/HRMS/DeleteOrganization", async (IOrganizationService service, [FromBody] OrganizationDeleteRequestDto dto, IOrganizationLogger logger) =>
            {
                logger.LogInformation("Deleting organization with ID {OrganizationId}.", dto.OrganizationID);

                var validator = new OrganizationDeleteRequestValidator();
                var validationResult = validator.Validate(dto);

                if (!validationResult.IsValid)
                {
                    var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    logger.LogWarning("Validation failed for deleting organization with ID {OrganizationId}: {Errors}", dto.OrganizationID, string.Join(", ", errorMessages));
                    return Results.BadRequest(
                      ResponseHelper<List<string>>.Error(
                          message: "Validation Failed",
                          errors: errorMessages,
                          statusCode: StatusCodeEnum.BAD_REQUEST
                      ).ToDictionary()
                  );
                }
                try
                {
                    var result = await service.DeleteOrganization(dto);
                    if (result == null)
                    {
                        logger.LogWarning("Organization with ID {OrganizationId} not found for deletion.", dto.OrganizationID);
                        return Results.NotFound(
                           ResponseHelper<string>.Error(
                               message: "Organization Not Found",
                               statusCode: StatusCodeEnum.NOT_FOUND
                           ).ToDictionary()
                       );
                    }

                    logger.LogInformation("Successfully deleted organization with ID {OrganizationId}.", dto.OrganizationID);
                    return Results.Ok(
                       ResponseHelper<OrganizationDeleteResponseDto>.Success(
                           message: "Organization Deleted Successfully",
                           data: result
                       ).ToDictionary()
                   );
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An unexpected error occurred while deleting the organization with ID {OrganizationId}.", dto.OrganizationID);
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Deleting the Organization.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            });
        }
    }
}



