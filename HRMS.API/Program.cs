using HRMS.API.Modules.User;
using HRMS.BusinessLayer.Interfaces;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.PersistenceLayer.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using HRMS.Utility.AutoMapperProfiles.User.UserMapping;
using HRMS.Utility.Validators.User.User;
using HRMS.Utility.AutoMapperProfiles.Leave.LeaveRequestMapping;

namespace HRMS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ILeaveService, UserService>();

            builder.Services.AddSingleton<IDbConnection>(_ => new SqlConnection(builder.Configuration.GetConnectionString("HRMS_DB")));

            builder.Services.AddAutoMapper(typeof(UserMappingProfile),typeof(LeaveRequestMappingProfile));

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.DescribeAllParametersInCamelCase();
            });

            builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
            {
                options.SerializerOptions.PropertyNamingPolicy = null;
            });

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<UserCreateRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UserUpdateRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UserReadRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UserDeleteRequestValidator>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapUserEndpoints();

            app.Run();
        }
    }
}
