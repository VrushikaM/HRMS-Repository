using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.Tenant.Organization.OrganizationRequestDtos;
using HRMS.Dtos.Tenant.Organization.OrganizationResponseDtos;
using HRMS.Utility.Helpers.Enums;
using HRMS.Utility.Helpers.Handlers;
using HRMS.Utility.Validators.Tenant.Organization;

using Microsoft.AspNetCore.Mvc;





namespace HRMS.API.Endpoints.Tenant
{
    public static class OrganizationEndpoints
    {

            public static void MapOrganizationEndpoints(this IEndpointRouteBuilder app)
            {
                
                app.MapGet("/HRMS/GetOrganizations", async (IOrganizationService service) =>
                {
                    var organizations = await service.GetOrganizations();
                    if (organizations != null && organizations.Any())
                    {
                        var response = ResponseHelper<List<OrganizationReadResponseDto>>.Success("Organizations Retrieved Successfully", organizations.ToList());
                        return Results.Ok(response.ToDictionary());
                    }

                    var errorResponse = ResponseHelper<IEnumerable<OrganizationReadResponseDto>>.Error("No Organizations Found");
                    return Results.NotFound(errorResponse.ToDictionary());
                });

                
                app.MapGet("/HRMS/Organization/{id}", async (IOrganizationService service, int id) =>
                {
                    var validator = new OrganizationReadRequestValidator();
                    var organizationRequestDto = new OrganizationReadRequestDto { OrganizationID = id };

                    var validationResult = validator.Validate(organizationRequestDto);
                    if (!validationResult.IsValid)
                    {
                        var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
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
                        var organization = await service.GetOrganization(id);
                        if (organization == null)
                        {
                            return Results.NotFound(
                                ResponseHelper<string>.Error(
                                    message: "Organization Not Found",
                                    statusCode: StatusCodeEnum.NOT_FOUND
                                ).ToDictionary()
                            );
                        }

                        return Results.Ok(
                            ResponseHelper<OrganizationReadResponseDto>.Success(
                                message: "Organization Retrieved Successfully",
                                data: organization
                            ).ToDictionary()
                        );
                    }
                    catch (Exception ex)
                    {
                        return Results.Json(
                            ResponseHelper<string>.Error(
                                message: "An Unexpected Error occurred.",
                                exception: ex,
                                isWarning: false,
                                statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                            ).ToDictionary()
                        );
                    }
                });


            app.MapPost("/CreateOrganization", async (OrganizationCreateRequestDto dto, IOrganizationService _organizationService) =>
            {
                var validator = new OrganizationCreateRequestValidator();
                var validationResult = validator.Validate(dto);

                if (!validationResult.IsValid)
                {
                    var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
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
                    return Results.Ok(
                        ResponseHelper<OrganizationCreateResponseDto>.Success(
                            message: "Organization Created Successfully",
                            data: newOrganization
                        ).ToDictionary()
                    );
                }
                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Creating the Organization.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );
                }
            });


            app.MapPut("/HRMS/UpdateOrganization", async (IOrganizationService service, [FromBody] OrganizationUpdateRequestDto dto) =>
            {
                var validator = new OrganizationUpdateRequestValidator();
                var validationResult = validator.Validate(dto);

                if (!validationResult.IsValid)
                {
                    var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

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
                        return Results.NotFound(
                           ResponseHelper<string>.Error(
                               message: "Organization Not Found",
                               statusCode: StatusCodeEnum.NOT_FOUND
                           ).ToDictionary()
                       );
                    }

                    return Results.Ok(
                        ResponseHelper<OrganizationUpdateResponseDto>.Success(
                            message: "Organization Updated Successfully",
                            data: updatedOrganization
                        ).ToDictionary()
                    );
                }
                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Updating the Organization.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );
                }
            });

            
            app.MapDelete("/HRMS/DeleteOrganization", async (IOrganizationService service, [FromBody] OrganizationDeleteRequestDto dto) =>
            {
                var validator = new OrganizationDeleteRequestValidator();
                var validationResult = validator.Validate(dto);

                if (!validationResult.IsValid)
                {
                    var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

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
                        return Results.NotFound(
                           ResponseHelper<string>.Error(
                               message: "Organization Not Found",
                               statusCode: StatusCodeEnum.NOT_FOUND
                           ).ToDictionary()
                       );
                    }

                    return Results.Ok(
                       ResponseHelper<OrganizationDeleteResponseDto>.Success(
                           message: "Organization Deleted Successfully",
                           data: result
                       ).ToDictionary()
                   );
                }

                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Deleting the Organization.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );
                }
            });
        }
    }
    }



