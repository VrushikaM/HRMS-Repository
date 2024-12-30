using FluentValidation;
using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.User.Roles.RolesRequestDtos;
using HRMS.Dtos.User.Roles.RolesResponseDtos;
using HRMS.Dtos.User.User.UserResponseDtos;
using HRMS.Utility.Helpers.Enums;
using HRMS.Utility.Helpers.Handlers;
using HRMS.Utility.Validators.User.Roles;
using HRMS.Utility.Validators.User.User;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Endpoints.User
{
    public static class RolesEndpoints
    {
        public static void MapRolesEndpoints(this IEndpointRouteBuilder app)
        {

            app.MapGet("/HRMS/GetAllRoles", async (IRolesService _rolesService) =>
            {


                var roles = await _rolesService.GetAllUserRoles();
                if (roles != null && roles.Any())
                {
                    var response = ResponseHelper<List<RolesReadResponseDto>>.Success("Roles Retrieved Successfully ", roles.ToList());
                    return Results.Ok(response.ToDictionary());
                }

                var errorResponse = ResponseHelper<List<UserReadResponseDto>>.Error("No Roles Found");
                return Results.NotFound(errorResponse.ToDictionary());
            }).WithTags("Roles");

            app.MapGet("/HRMS/GetRolesById{id}", async (IRolesService _rolesService, int id) =>
            {
                var validator = new RolesReadRequestValidator();
                var rolesRequestDto = new RolesReadRequestDto { RoleId = id };

                var validationResult = validator.Validate(rolesRequestDto);
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
                    var role = await _rolesService.GetUserRolesById(id);
                    if (role == null)
                    {
                        return Results.NotFound(
                            ResponseHelper<string>.Error(
                                message: "Role Not Found ",
                                statusCode: StatusCodeEnum.NOT_FOUND
                                ).ToDictionary()
                                );
                    }

                    return Results.Ok(
                        ResponseHelper<RolesReadResponseDto>.Success(
                            message: "Role Retrieved Successfully",
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
            }).WithTags("Roles");

            app.MapPost("/CreateRole", async (RolesCreateRequestDto dto, IRolesService _rolesService) =>
            {
                var validator = new RolesCreateRequestValidator();
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
                    var newRole = await _rolesService.CreateUserRole(dto);
                    return Results.Ok(
                        ResponseHelper<RolesCreateResponseDto>.Success(
                            message: "Role Created Successfully",
                            data: newRole
                        ).ToDictionary()
                    );
                }

                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Creating the Role.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );
                }
            }).WithTags("Roles");

            app.MapPut("/HRMS/UpdateRoles", async (IRolesService _rolesService, [FromBody] RolesUpdateRequestDto dto) =>
            {
                var validator = new RolesUpdateRequestValidator();
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
                    var updatedRoles = await _rolesService.UpdateUserRoles(dto);
                    if (updatedRoles == null)
                    {
                        return Results.NotFound(
                            ResponseHelper<string>.Error(
                                message: "Roles Not Found",
                                statusCode: StatusCodeEnum.NOT_FOUND
                            ).ToDictionary()
                         );
                    }
                    return Results.Ok(
                        ResponseHelper<RolesUpdateResponseDto>.Success(
                            message: "Roles Updated Succesfully ",
                            data: updatedRoles
                            ).ToDictionary()
                        );

                }
                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Updating the Roles.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );

                }

            }).WithTags("Roles");

            app.MapDelete("/HRMS/DeleteRoles", async(IRolesService _rolesService, [FromBody] RolesDeleteRequestDto dto) =>
            {
                var validator = new RolesDeleteRequestValidator();
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
                    var result = await _rolesService.DeleteUserRoles(dto);
                if (result == null)
                    {
                        return Results.NotFound(
                            ResponseHelper<string>.Error(
                                message: "Roles Not Found",
                                statusCode: StatusCodeEnum.NOT_FOUND
                                ).ToDictionary()
                            );
                    }

                    return Results.Ok(
                           ResponseHelper<RolesDeleteResponseDto>.Success(
                               message: "Role Deleted Successfully",
                               data: result
                           ).ToDictionary()
                       );
                }
                catch(Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Deleting the Roles.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );

                }
            }).WithTags("Roles");


        }

    }
}
