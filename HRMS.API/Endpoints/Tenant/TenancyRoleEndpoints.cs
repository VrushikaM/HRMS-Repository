using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.Tenant.TenancyRole.TenancyRoleRequestDtos;
using HRMS.Dtos.Tenant.TenancyRole.TenancyRoleResponseDtos;
using HRMS.Utility.Helpers.Enums;
using HRMS.Utility.Helpers.Handlers;
using HRMS.Utility.Validators.Tenant.TenancyRole;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Endpoints.Tenant
{
    public static class TenancyRoleEndpoints
    {
        public static void MapTenancyRoleEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/HRMS/GetTenancyRoles", async (ITenancyRoleService service) =>
            {
                var roles = await service.GetTenancyRoles();
                if (roles != null && roles.Any())
                {
                    var response = ResponseHelper<List<TenancyRoleReadResponseDto>>.Success("Tenancy Roles Retrieved Successfully", roles.ToList());
                    return Results.Ok(response.ToDictionary());
                }

                var errorResponse = ResponseHelper<List<TenancyRoleReadResponseDto>>.Error("No Tenancy Roles Found");
                return Results.NotFound(errorResponse.ToDictionary());
            });

            app.MapGet("/HRMS/TenancyRole/{id}", async (ITenancyRoleService service, int id) =>
            {
                var validator = new TenancyRoleReadRequestValidator();
                var roleRequestDto = new TenancyRoleReadRequestDto { TenancyRoleID = id };

                var validationResult = validator.Validate(roleRequestDto);
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
                    var role = await service.GetTenancyRoleById(id);
                    if (role == null)
                    {
                        return Results.NotFound(
                            ResponseHelper<string>.Error(
                                message: "Tenancy Role Not Found",
                                statusCode: StatusCodeEnum.NOT_FOUND
                            ).ToDictionary()
                        );
                    }
                    return Results.Ok(
                        ResponseHelper<TenancyRoleReadResponseDto>.Success(
                            message: "Tenancy Role Retrieved Successfully",
                            data: role
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

            app.MapPost("/HRMS/CreateTenancyRole", async (TenancyRoleCreateRequestDto dto, ITenancyRoleService _tenancyroleService) =>
            {
                var validator = new TenancyRoleCreateRequestValidator();
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
                    var newRole = await _tenancyroleService.CreateTenancyRole(dto);
                    return Results.Ok(
                        ResponseHelper<TenancyRoleCreateResponseDto>.Success(
                            message: "Tenancy Role Created Successfully",
                            data: newRole
                        ).ToDictionary()
                    );
                }
                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Creating the Tenancy Role.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );
                }
            });

            app.MapPut("/HRMS/UpdateTenancyRole", async (ITenancyRoleService service, [FromBody] TenancyRoleUpdateRequestDto dto) =>
            {
                var validator = new TenancyRoleUpdateRequestValidator();
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
                    var updatedTenancyRole = await service.UpdateTenancyRole(dto);
                    if (updatedTenancyRole == null)
                    {
                        return Results.NotFound(
                           ResponseHelper<string>.Error(
                               message: "Tenancy Role Not Found",
                               statusCode: StatusCodeEnum.NOT_FOUND
                           ).ToDictionary()
                       );
                    }

                    return Results.Ok(
                        ResponseHelper<TenancyRoleUpdateResponseDto>.Success(
                            message: "Tenancy Role Updated Successfully",
                            data: updatedTenancyRole
                        ).ToDictionary()
                    );
                }
                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Updating the Tenancy Role.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );
                }
            });

            app.MapDelete("/HRMS/DeleteTenancyRole", async (ITenancyRoleService service, [FromBody] TenancyRoleDeleteRequestDto dto) =>
            {
                var validator = new TenancyRoleDeleteRequestValidator();
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
                    var result = await service.DeleteTenancyRole(dto);
                    if (result == null)
                    {
                        return Results.NotFound(
                           ResponseHelper<string>.Error(
                               message: "Tenancy Role Not Found",
                               statusCode: StatusCodeEnum.NOT_FOUND
                           ).ToDictionary()
                       );
                    }

                    return Results.Ok(
                       ResponseHelper<TenancyRoleDeleteResponseDto>.Success(
                           message: "Tenancy Role Deleted Successfully",
                           data: result
                       ).ToDictionary()
                   );
                }
                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Deleting the Tenancy Role.",
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
