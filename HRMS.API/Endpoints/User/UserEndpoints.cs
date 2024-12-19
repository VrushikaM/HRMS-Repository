using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.User.UserRequestModels;
using HRMS.Utility.Helper;
using HRMS.Utility.Validators.User;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Modules.User
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/HRMS/GetUsers", async (IUserService service) =>
            {
                var users = await service.GetUsers();
                if (users != null && users.Any())
                {
                    return Results.Ok(ResponseHandler.Success("Users Retrieved Successfully", users).ToDictionary());
                }
                return Results.NotFound(ResponseHandler.Error("No Users Found"));
            });

            app.MapGet("/HRMS/User/{id}", async (IUserService service, int id) =>
            {
                var validator = new UserReadRequestValidator();
                var userRequestDto = new UserReadRequestDto { UserId = id };

                var validationResult = validator.Validate(userRequestDto);
                if (!validationResult.IsValid)
                {
                    var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    return Results.BadRequest(ResponseHandler.Error("Validation Failed", errorMessages).ToDictionary());
                }

                var user = await service.GetUser(id);
                if (user == null)
                {
                    return Results.NotFound(ResponseHandler.Error("User Not Found", new List<string>()).ToDictionary());
                }

                return Results.Ok(ResponseHandler.Success("User Retrieved Successfully", user).ToDictionary());
            });

            app.MapPost("/CreateUser", async (UserCreateRequestDto dto, IUserService _userService) =>
            {
                var validator = new UserCreateRequestValidator();
                var validationResult = validator.Validate(dto);

                if (!validationResult.IsValid)
                {
                    var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    return Results.BadRequest(ResponseHandler.Error("Validation Failed", errorMessages).ToDictionary());
                }

                var newUser = await _userService.CreateUser(dto);
                return Results.Ok(ResponseHandler.Success("User Created Successfully", newUser).ToDictionary());
            });

            app.MapPut("/HRMS/UpdateUser", async (IUserService service, [FromBody] UserUpdateRequestDto dto) =>
            {
                var validator = new UserUpdateRequestValidator();
                var validationResult = validator.Validate(dto);

                if (!validationResult.IsValid)
                {
                    var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    return Results.BadRequest(ResponseHandler.Error("Validation Failed", errorMessages).ToDictionary());
                }

                var updatedUser = await service.UpdateUser(dto);
                if (updatedUser == null)
                {
                    return Results.NotFound(ResponseHandler.Error("User Not Found", new List<string>()).ToDictionary());
                }

                return Results.Ok(ResponseHandler.Success("User Updated Successfully", updatedUser).ToDictionary());
            });

            app.MapDelete("/HRMS/DeleteUser", async (IUserService service, [FromBody] UserDeleteRequestDto dto) =>
            {
                if (dto == null || dto.UserId <= 0)
                    return Results.BadRequest(ResponseHandler.Error("Invalid Request Payload or User ID"));

                await service.DeleteUser(dto);
                return Results.Ok(ResponseHandler.Success("User Deleted Successfully").ToDictionary());
            });
        }
    }
}
