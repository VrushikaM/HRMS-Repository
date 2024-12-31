using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.Subdomain.Subdomain.SubdomainRequestDto;
using HRMS.Dtos.Subdomain.Subdomain.SubdomainResponseDto;
using HRMS.Utility.Helpers.Enums;
using HRMS.Utility.Helpers.Handlers;
using HRMS.Utility.Validators.Subdomain.Subdomain;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Endpoints.Subdomain
{
    public static class SubdomainEndpoints
    {
        public static void MapSubdomainEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/HRMS/GetSubdomains", async (ISubdomainService service) =>
            {
                var subdomains = await service.GetSubdomains();
                if (subdomains != null && subdomains.Any())
                {
                    var response = ResponseHelper<List<SubdomainReadResponseDto>>.Success("Subdomains Retrieved Successfully", subdomains.ToList());
                    return Results.Ok(response.ToDictionary());
                }

                var errorResponse = ResponseHelper<List<SubdomainReadResponseDto>>.Error("No Subdomains Found");
                return Results.NotFound(errorResponse.ToDictionary());
            });

            app.MapGet("/HRMS/Subdomain/{id}", async (ISubdomainService service, int id) =>
            {
                var validator = new SubdomainReadRequestValidator();
                var subdomainRequestDto = new SubdomainReadRequestDto { SubdomainID = id };

                var validationResult = validator.Validate(subdomainRequestDto);
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
                    var subdomain = await service.GetSubdomainById(id);
                    if (subdomain == null)
                    {
                        return Results.NotFound(
                            ResponseHelper<string>.Error(
                                message: "Subdomain Not Found",
                                statusCode: StatusCodeEnum.NOT_FOUND
                            ).ToDictionary()
                        );
                    }

                    return Results.Ok(
                        ResponseHelper<SubdomainReadResponseDto>.Success(
                            message: "Subdomain Retrieved Successfully",
                            data: subdomain
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

            app.MapPost("/CreateSubdomain", async (SubdomainCreateRequestDto dto, ISubdomainService _subdomainservice) =>
            {
                var validator = new SubdomainCreateRequestValidator();
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
                    var newUser = await _subdomainservice.CreateSubdomain(dto);
                    return Results.Ok(
                        ResponseHelper<SubdomainCreateResponseDto>.Success(
                            message: "Subdomain Created Successfully",
                            data: newUser
                        ).ToDictionary()
                    );
                }
                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Creating the Subdomain.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );
                }
            });

            app.MapPut("/HRMS/UpdateSubdomain", async (SubdomainUpdateRequestDto dto, ISubdomainService _subdomainservice) =>
            {
                var validator = new SubdomainUpdateRequestValidator();
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
                    var updatedSubdomain = await _subdomainservice.UpdateSubdomain(dto);
                    return Results.Ok(
                        ResponseHelper<SubdomainUpdateResponseDto>.Success(
                            message: "Subdomain Updated Successfully",
                            data: updatedSubdomain
                        ).ToDictionary()
                    );
                }
                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Updating the Subdomain.",
                            exception: ex,
                            isWarning: false,
                            statusCode: StatusCodeEnum.INTERNAL_SERVER_ERROR
                        ).ToDictionary()
                    );
                }
            });

            app.MapDelete("/HRMS/DeleteSubdomain", async (ISubdomainService service, [FromBody] SubdomainDeleteRequestDto dto) =>
            {
                var validator = new SubdomainDeleteRequestValidator();
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
                    var result = await service.DeleteSubdomain(dto);
                    if (result == null)
                    {
                        return Results.NotFound(
                           ResponseHelper<string>.Error(
                               message: "Subdomain Not Found",
                               statusCode: StatusCodeEnum.NOT_FOUND
                           ).ToDictionary()
                       );
                    }

                    return Results.Ok(
                       ResponseHelper<SubdomainDeleteResponseDto>.Success(
                           message: "Subdomain Deleted Successfully",
                           data: result
                       ).ToDictionary()
                   );
                }
                catch (Exception ex)
                {
                    return Results.Json(
                        ResponseHelper<string>.Error(
                            message: "An Unexpected Error occurred while Deleting the Subdomain.",
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
