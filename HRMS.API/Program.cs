using FluentValidation;
using FluentValidation.AspNetCore;
using HRMS.API.Endpoints.Tenant;
using HRMS.API.Modules.User;
using HRMS.BusinessLayer.Interfaces;
using HRMS.BusinessLayer.Services;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.PersistenceLayer.Repositories;
using HRMS.Utility.AutoMapperProfiles.Tenant.TenantMapping;
using HRMS.Utility.Validators.Tenant.Tenant;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HRMS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITenantRepository, TenantRepository>();
            builder.Services.AddScoped<ITenantService, TenantService>();

            builder.Services.AddSingleton<IDbConnection>(_ => new SqlConnection(builder.Configuration.GetConnectionString("HRMS_DB")));

            builder.Services.AddAutoMapper(typeof(TenantMappingProfile));

            builder.Services.AddAuthorization();
            builder.Services.AddCors();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.DescribeAllParametersInCamelCase();
                options.EnableAnnotations();
            });

            builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
            {
                options.SerializerOptions.PropertyNamingPolicy = null;
            });

            builder.Services.AddFluentValidationAutoValidation();
           
            builder.Services.AddValidatorsFromAssemblyContaining<TenantCreateRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<TenantUpdateRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<TenantReadRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<TenantDeleteRequestValidator>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthorization();

            app.MapUserEndpoints();
            app.MapTenantEndpoints();

            app.Run("https://192.168.1.198:7196");
        }
    }
}
