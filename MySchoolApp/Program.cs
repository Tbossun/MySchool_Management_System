using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySchool.Core;
using MySchool.Core.Interface;
using MySchool.Data;
using MySchool.Models.Entities;
using MySchoolApp.Extensions;
using Serilog;
using Serilog.Extensions.Logging;
using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using MySchool.Core.Utils;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File("log/MySchoolLogs.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        builder.Host.UseSerilog();
        builder.Services.AddControllers();

        //Configure swagger to use authentication
        builder.Services.AddSwaggerGen(setup =>
        {
            setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "MySchool.API",
                Version = "v1"

            });

            // To Enable authorization using Swagger (JWT) 
            setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter 'Bearer' [space] and then your valid token in the text input below \r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\""
            });
            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
        });

        //Register DbContext
        builder.Services.AddDbContext<MySchoolDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("Con")));

        //Identity
        builder.Services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<MySchoolDbContext>().AddDefaultTokenProviders();
        
        //Add Config for confirm email requirment
        builder.Services.Configure<IdentityOptions>(
            options => options.SignIn.RequireConfirmedEmail = true);

        //
        builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
        options.TokenLifespan = TimeSpan.FromMinutes(30));

        //Configure Authententication
        builder.Services.AddAuthentication(options =>
        {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = configuration["JWT:ValidAudience"],
                ValidIssuer = configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
                ClockSkew = TimeSpan.FromSeconds(30)
            };
        });

        //Register Automapper
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        //Register unitOfWork
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IImageService, ImageService>();
        builder.Services.Configure<ImageUploadSettings>(builder.Configuration.GetSection("ImageUploadSettings"));


        /* builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
         builder.Services.AddScoped<IUrlHelper>(x =>
         {
             var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
             var factory = x.GetRequiredService<IUrlHelperFactory>();
             return factory.GetUrlHelper(actionContext);
         })*/
        ;
       // builder.Services.AddScoped<IAuthService, AuthService>();

        //Register Email
        var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
        builder.Services.AddSingleton(emailConfig);
        builder.Services.AddScoped<IEmailService, EmailService>();

        builder.Services.AddEndpointsApiExplorer();

        var loggerFactory = new SerilogLoggerFactory(Log.Logger);
        builder.Services.AddSingleton<ILoggerFactory>(loggerFactory);

        
        var app = builder.Build();
        var logger = app.Services.GetRequiredService<ILogger<Program>>();

        //configure seeder
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<MySchoolDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            // Seed the data
            Seeder.SeedDataBase(roleManager, userManager, dbContext);
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.ConfigureExceptionHandler(logger);
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();
        app.Run();
    }
}
                                                                  