using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.User.UserRoles.UserRolesRequestDtos;
using HRMS.Dtos.User.UserRoles.UserRolesResponseDtos;
using HRMS.Dtos.User.User.UserResponseDtos;
using HRMS.Utility.Helpers.Enums;
using HRMS.Utility.Helpers.Handlers;
using HRMS.Utility.Validators.User.UserRoles;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Endpoints.User
{
    public static class UserRolesEndpoints
    {
        public static void MapUserRolesEndpoints(this IEndpointRouteBuilder app)
        {

            app.MapGet("/HRMS/GetAllUserRoles", async (IUserRolesService _rolesService) =>
            {
                var roles = await _rolesService.GetAllUserRoles();
                if (roles != null && roles.Any())
                {
                    var response = ResponseHelper<List<UserRolesReadResponseDto>>.Success("User Roles Retrieved Successfully ", roles.ToList());
                    return Results.Ok(response.ToDictionary());
                }

                var errorResponse = ResponseHelper<List<UserReadResponseDto>>.Error("No User Roles Found");
                return Results.NotFound(errorResponse.ToDictionary());
            }).WithTags("UserRoles");

            app.MapGet("/HRMS/GetUserRolesById{id}", async (IUserRolesService _rolesService, int id) =>
            {
                var validator = new UserRolesReadRequestValidator();
                var rolesRequestDto = new UserRolesReadRequestDto { RoleId = id };

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
                        ResponseHelper<UserRolesReadResponseDto>.Success(
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
            }).WithTags("UserRoles");

            app.MapPost("/CreateRole", async (UserRolesCreateRequestDto dto, IUserRolesService _rolesService) =>
            {
                var validator = new UserRolesCreateRequestValidator();
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
                        ResponseHelper<UserRolesCreateResponseDto>.Success(
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
            }).WithTags("UserRoles");

            app.MapPut("/HRMS/UpdateRoles", async (IUserRolesService _rolesService, [FromBody] UserRolesUpdateRequestDto dto) =>
            {
                var validator = new UserRolesUpdateRequestValidator();
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
                    var updatedUserRoles = await _rolesService.UpdateUserRoles(dto);
                    if (updatedUserRoles == null)
                    {
                        return Results.NotFound(
                            ResponseHelper<string>.Error(
                                message: "User Roles Not Found",
                                statusCode: StatusCodeEnum.NOT_FOUND
                            ).ToDictionary()
                         );
                    }
                    return Results.Ok(
                        ResponseHelper<UserRolesUpdateResponseDto>.Success(
                            message: "User Roles Updated Succesfully ",
                            data: updatedUserRoles
                            ).ToDictionary()
                        );
                }
                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Updating the User Roles.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );

                }

            }).WithTags("User Roles");

            app.MapDelete("/HRMS/DeleteUserRoles", async (IUserRolesService _rolesService, [FromBody] UserRolesDeleteRequestDto dto) =>
            {
                var validator = new UserRolesDeleteRequestValidator();
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
                                message: "User Roles Not Found",
                                statusCode: StatusCodeEnum.NOT_FOUND
                                ).ToDictionary()
                            );
                    }

                    return Results.Ok(
                           ResponseHelper<UserRolesDeleteResponseDto>.Success(
                               message: "Role Deleted Successfully",
                               data: result
                           ).ToDictionary()
                       );
                }
                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Deleting the User Roles.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );

                }
            }).WithTags("UserRoles");
        }
    }
}
