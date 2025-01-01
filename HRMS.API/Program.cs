using FluentValidation;
using FluentValidation.AspNetCore;
using HRMS.API.Endpoints.Tenant;
using HRMS.API.Endpoints.User;
using HRMS.API.Modules.User;
using HRMS.BusinessLayer.Interfaces;
using HRMS.BusinessLayer.Services;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.PersistenceLayer.Repositories;
using HRMS.Utility.AutoMapperProfiles.Tenant.TenancyRoleMapping;
using HRMS.Utility.AutoMapperProfiles.User.UserMapping;
using HRMS.Utility.AutoMapperProfiles.User.UserRolesMapping;
using HRMS.Utility.Validators.Tenant.TenancyRole;
using HRMS.Utility.Validators.User.User;
using HRMS.Utility.Validators.User.UserRoles;
using HRMS.Utility.Validators.User.UserRolesMapping;
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
            builder.Services.AddScoped<ITenancyRoleService, TenancyRoleService>();
            builder.Services.AddScoped<ITenancyRoleRepository, TenancyRoleRepository>();
            builder.Services.AddScoped<IUserRolesRepository, UserRolesRepository>();
            builder.Services.AddScoped<IUserRolesService, UserRolesService>();
            builder.Services.AddScoped<IUserRolesMappingRepository, UserRolesMappingRepository>();
            builder.Services.AddScoped<IUserRolesMappingService, UserRolesMappingService>();
            

            builder.Services.AddSingleton<IDbConnection>(_ => new SqlConnection(builder.Configuration.GetConnectionString("HRMS_DB")));

            builder.Services.AddAutoMapper(typeof(UserMappingProfile), typeof(TenancyRoleMappingProfile), typeof(UserRolesMappingProfile),typeof(UserRolesMappingProfile));

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

            builder.Services.AddValidatorsFromAssemblyContaining<TenancyRoleCreateRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<TenancyRoleUpdateRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<TenancyRoleReadRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<TenancyRoleDeleteRequestValidator>();

            builder.Services.AddValidatorsFromAssemblyContaining<UserRolesCreateRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UserRolesUpdateRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UserRolesReadRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UserRolesDeleteRequestValidator>();

            builder.Services.AddValidatorsFromAssemblyContaining<UserRolesMappingCreateRequestValidator>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapUserEndpoints();
            app.MapTenancyRoleEndpoints();
            app.MapUserRolesEndpoints();
            app.MapUserRolesMappingEndpoints();

            app.Run();
        }
    }
}
