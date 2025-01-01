using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.User.UserRoles.UserRolesRequestDtos;
using HRMS.Dtos.User.UserRolesMapping.UserRolesMappingRequestDtos;
using HRMS.Dtos.User.UserRolesMapping.UserRolesMappingResponseDtos;
using HRMS.Utility.Helpers.Enums;
using HRMS.Utility.Helpers.Handlers;
using HRMS.Utility.Validators.User.UserRoles;
using HRMS.Utility.Validators.User.UserRolesMapping;

namespace HRMS.API.Endpoints.User
{
    public static class UserRolesMapping
    {
        public static void MapUserRolesMappingEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/CreateUserRolesMapping", async (UserRolesMappingCreateRequestDto dto, IUserRolesMappingService _rolesmappingService) =>
            {
                var validator = new UserRolesMappingCreateRequestValidator();
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
                    var newrolemapping = await _rolesmappingService.CreateUserRoleMapping(dto);
                    return Results.Ok(
                        ResponseHelper<UserRolesMappingCreateResponseDto>.Success(
                            message: "User Role Mapping Created Successfully",
                            data: newrolemapping
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
            }).WithTags("UserRolesMapping");


            //app.MapPut(/UpdateRolesMapping")Future Enhansement
            //app.MapDelete(/DeleteRolesMapping")Future Enhansement
        }
    }
}
