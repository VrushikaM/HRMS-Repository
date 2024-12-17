using HRMS.Dtos.User;
using HRMS.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HRMS.Entities.Models;
using HRMS.Utility.Helper;

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
                var user = await service.GetUser(id);
                if (user != null)
                {
                    return Results.Ok(ResponseHandler.Success("User Retrieved Successfully", user.First()).ToDictionary());
                }
                return Results.NotFound(ResponseHandler.Error("User Not Found"));
            });

            app.MapPost("/HRMS/CreateUser", async (IUserService service, UserCreateDto dto) =>
            {
                Users newUser = await service.CreateUser(dto);
                return Results.Ok(ResponseHandler.Success("User Created Successfully", newUser).ToDictionary());
            });

            app.MapPut("/HRMS/UpdateUser", async (IUserService service, UserUpdateDto dto) =>
            {
                Users updatedUser = await service.UpdateUser(dto);
                return Results.Ok(ResponseHandler.Success("User Updated Successfully", updatedUser).ToDictionary());
            });

            app.MapDelete("/HRMS/DeleteUser", async (IUserService service, [FromBody] UserDeleteDto dto) =>
            {
                await service.DeleteUser(dto);
                return Results.Ok(ResponseHandler.Success("User Deleted Successfully").ToDictionary());
            });
        }
    }
}
