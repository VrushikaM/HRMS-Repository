using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.Leave.Leave.LeaveResponseDtos;
using HRMS.Utility.Helpers.Handlers;


namespace HRMS.API.Endpoints.Leave
{
    public static class LeaveRequestEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/HRMS/GetLeaves", async (ILeaveService service) =>
            {
                var leaves = await service.GetLeaves();
                if (leaves != null && leaves.Any())
                {
                    var response = ResponseHelper<List<LeaveRequestReadResponseDto>>.Success("leaves Retrieved Successfully", leaves.Tolist());
                    return Results.Ok(response.ToDictionary());
                }

                var errorResponse = ResponseHelper<List<LeaveRequestReadResponseDto>>.Error("No Users Found");
                return Results.NotFound(errorResponse.ToDictionary());
            });
        }
    }
}