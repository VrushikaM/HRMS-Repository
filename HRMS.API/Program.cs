using HRMS.API.Modules.User;
using HRMS.BusinessLayer.AutoMapperProfiles.UserMapping;
using HRMS.BusinessLayer.Interfaces;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.PersistenceLayer.Repositories;
using HRMS.Utility.Validators.User;
using Microsoft.Data.SqlClient;
using System.Data;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace HRMS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddSingleton<IDbConnection>(_ => new SqlConnection(builder.Configuration.GetConnectionString("HRMS_DB")));

            builder.Services.AddAutoMapper(typeof(UserMappingProfile));

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

            builder.Services.AddValidatorsFromAssemblyContaining<UserReadRequestValidator>();
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
