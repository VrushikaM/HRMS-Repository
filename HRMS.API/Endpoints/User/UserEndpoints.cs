using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.User.UserRequestModels;
using HRMS.Utility.Helper;
using HRMS.Utility.Validators.User;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HRMS.API.Modules.User
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            /// <summary> 
            /// Retrieves a list of users. 
            /// </summary> 
            /// <remarks> 
            /// This endpoint returns a list of users. If no users are found, a 404 status code is returned. 
            /// </remarks> 
            /// <returns>A list of users or a 404 status code if no users are found.</returns>
            app.MapGet("/GetUsers", async (IUserService service) =>
            {
                var users = await service.GetUsers();
                if (users != null && users.Any())
                {
                    return Results.Ok(ResponseHandler.Success("Users Retrieved Successfully", users).ToDictionary());
                }
                return Results.NotFound(ResponseHandler.Error("No Users Found"));
            }).WithTags("User")
            .WithMetadata(new SwaggerOperationAttribute(summary: "Retrieves a list of users", description: "This endpoint returns a list of users. If no users are found, a 404 status code is returned."
            ));

            /// <summary> 
            /// Retrieve user by Id. 
            /// </summary> 
            /// <remarks> 
            /// This endpoint return user by Id. If no user are found, a 404 status code is returned. 
            /// </remarks> 
            /// <returns>A user or a 404 status code if no user are found.</returns>
            app.MapGet("/User/{id}", async (IUserService service, int id) =>
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
            }).WithTags("User")
            .WithMetadata(new SwaggerOperationAttribute(summary: "Retrieve user by Id.", description: "This endpoint return user by Id. If no user are found, a 404 status code is returned."
            ));

            /// <summary> 
            /// Creates a new user. 
            /// </summary> 
            /// <remarks> 
            /// This endpoint allows you to create a new user with the provided details. 
            /// </remarks> 
            ///<returns> A success or error response based on the operation result.</returns >
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
            }).WithTags("User")
            .WithMetadata(new SwaggerOperationAttribute(summary: "Creates a new user", description: "This endpoint allows you to create a new user with the provided details."
            ));

            /// <summary> 
            /// Updates existing user details. 
            /// </summary> 
            /// <remarks> 
            /// This endpoint allows you to update user details with the provided Id. 
            /// </remarks> 
            ///<returns> A success or error response based on the operation result.</returns >
            app.MapPut("/UpdateUser", async (IUserService service, [FromBody] UserUpdateRequestDto dto) =>
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
            }).WithTags("User")
            .WithMetadata(new SwaggerOperationAttribute(summary: "Updates existing user details", description: "This endpoint allows you to update user details with the provided Id."
            ));

            /// <summary> 
            /// Deletes a user. 
            /// </summary> 
            /// <remarks> 
            /// This endpoint allows you to delete a tenant based on the provided tenant ID. 
            /// </remarks>
            app.MapDelete("/DeleteUser", async (IUserService service, [FromBody] UserDeleteRequestDto dto) =>
            {
                var validator = new UserDeleteRequestValidator();
                var validationResult = validator.Validate(dto);

                if (!validationResult.IsValid)
                {
                    var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    return Results.BadRequest(ResponseHandler.Error("Validation Failed", errorMessages).ToDictionary());
                }

                var result = await service.DeleteUser(dto);
                if (result == null)
                {
                    return Results.NotFound(ResponseHandler.Error("User Not Found", new List<string>()).ToDictionary());
                }

                return Results.Ok(ResponseHandler.Success("User Deleted Successfully").ToDictionary());
            }).WithTags("User")
            .WithMetadata(new SwaggerOperationAttribute(summary: "Deletes a user ", description: "This endpoint allows you to delete a user based on the provided user ID."
            ));
        }
    }
}
