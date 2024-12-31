using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.Tenant.Tenant.TenantRequestDtos;
using HRMS.Dtos.Tenant.Tenant.TenantResponseDtos;
using HRMS.Utility.Validators.Tenant.Tenant;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;




namespace HRMS.API.Endpoints.Tenant
{
    public static class TenantEndpoints
    {
        public static void MapTenantEndpoints(this IEndpointRouteBuilder app)
        {
            /// <summary> 
            /// Retrieves a list of tenants. 
            /// </summary> 
            /// <remarks> 
            /// This endpoint returns a list of tenants. If no tenants are found, a 404 status code is returned. 
            /// </remarks> 
            /// <returns>A list of tenants or a 404 status code if no tenants are found.</returns>
            app.MapGet("/GetTenants", async (ITenantService service) =>
            {
                var tenant = await service.GetTenants();
                if (tenant != null && tenant.Any())
                {
                    var response = ResponseHelper<List<TenantReadResponseDtos>>.Success("Tenants Retrieved Successfully", tenant.ToList());
                    return Results.Ok(response.ToDictionary());
                }
                var errorResponse = ResponseHelper<List<TenantReadResponseDtos>>.Error("No Tenants Found");
                return Results.NotFound(errorResponse.ToDictionary());
            }).WithTags("Tenant")
            .WithMetadata(new SwaggerOperationAttribute(summary: "Retrieves a list of tenants", description: "This endpoint returns a list of tenants. If no tenants are found, a 404 status code is returned."
            ));

            /// <summary> 
            /// Retrieve tenant by Id. 
            /// </summary> 
            /// <remarks> 
            /// This endpoint return tenant by Id. If no tenant are found, a 404 status code is returned. 
            /// </remarks> 
            /// <returns>A tenant or a 404 status code if no tenant are found.</returns>
            app.MapGet("/GetTenant/{id}", async (ITenantService service, int id) =>
            {
                var validator = new TenantReadRequestValidator();
                var tenantRequestDto = new TenantReadRequestDtos { TenantID = id };

                var validationResult = validator.Validate(tenantRequestDto);
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
                    var tenant = await service.GetTenant(id);
                    if (tenant == null)
                    {
                        return Results.NotFound(
                            ResponseHelper<string>.Error(
                                message: "Tenant Not Found",
                                statusCode: StatusCodeEnum.NOT_FOUND
                            ).ToDictionary()
                        );
                    }

                    return Results.Ok(
                        ResponseHelper<TenantReadResponseDtos>.Success(
                            message: "User Retrieved Successfully",
                            data: tenant
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
            }).WithTags("Tenant")
            .WithMetadata(new SwaggerOperationAttribute(summary: "Retrieve tenant by Id", description: "This endpoint return tenant by Id. If no tenant are found, a 404 status code is returned. "
            ));

            /// <summary> 
            /// Creates a new tenant. 
            /// </summary> 
            /// <remarks> 
            /// This endpoint allows you to create a new tenant with the provided details. 
            /// </remarks> 
            ///<returns> A success or error response based on the operation result.</returns >
            app.MapPost("/CreateTenant", async (TenantCreateRequestDtos dto, ITenantService _service) =>
            {
                var validator = new TenantCreateRequestValidator();
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
                    var newUser = await _service.CreateTenant(dto);
                    return Results.Ok(
                        ResponseHelper<TenantCreateResponseDtos>.Success(
                            message: "Tenant Created Successfully",
                            data: newUser
                        ).ToDictionary()
                    );
                }

                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Creating the Tenant.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );
                }
            }).WithTags("Tenant")
            .WithMetadata(new SwaggerOperationAttribute(summary: "Creates a new tenant.", description: "This endpoint allows you to create a new tenant with the provided details. "
            ));

            /// <summary> 
            /// Updates existing tenant details. 
            /// </summary> 
            /// <remarks> 
            /// This endpoint allows you to update tenant details with the provided Id. 
            /// </remarks> 
            ///<returns> A success or error response based on the operation result.</returns >
            app.MapPut("/UpdateTenant", async (ITenantService _service, [FromBody] TenantUpdateRequestDtos dto) =>
            {
                var validator = new TenantUpdateRequestValidator();
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
                    var updatedTenant = await _service.UpdateTenant(dto);
                    if (updatedTenant == null)
                    {
                        return Results.NotFound(
                           ResponseHelper<string>.Error(
                               message: "User Not Found",
                               statusCode: StatusCodeEnum.NOT_FOUND
                           ).ToDictionary()
                       );
                    }

                    return Results.Ok(
                        ResponseHelper<TenantUpdateResponseDtos>.Success(
                            message: "Tenant Updated Successfully",
                            data: updatedTenant
                        ).ToDictionary()
                    );
                }

                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Updating the User.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );
                }
            }).WithTags("Tenant")
            .WithMetadata(new SwaggerOperationAttribute(summary: "Updates existing tenant details", description: "This endpoint allows you to update tenant details with the provided Id. "
            ));

            /// <summary> 
            /// Deletes a user. 
            /// </summary> 
            /// <remarks> 
            /// This endpoint allows you to delete a tenant based on the provided tenant ID. 
            /// </remarks>
            app.MapDelete("/DeleteTenant", async (ITenantService service, [FromBody] TenantDeleteRequestDtos dto) =>
            {
                var validator = new TenantDeleteRequestValidator();
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
                    var result = await service.DeleteTenant(dto);
                    if (result == null)
                    {
                        return Results.NotFound(
                           ResponseHelper<string>.Error(
                               message: "User Not Found",
                               statusCode: StatusCodeEnum.NOT_FOUND
                           ).ToDictionary()
                       );
                    }

                    return Results.Ok(
                       ResponseHelper<TenantDeleteResponseDtos>.Success(
                           message: "Tenant Deleted Successfully",
                           data: result
                       ).ToDictionary()
                   );
                }

                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Deleting the Tenant.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );
                }
            }).WithTags("Tenant")
            .WithMetadata(new SwaggerOperationAttribute(summary: "Deletes a user. ", description: "This endpoint allows you to delete a tenant based on the provided tenant ID."
            ));
        }
    }
}
