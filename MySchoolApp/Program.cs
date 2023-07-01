using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MySchool.Data;
using MySchool.Data.Context;
using MySchool.Models.Entities;
using MySchoolApp.Extensions;
using Serilog;
using Serilog.Extensions.Logging;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("log/MySchoolLogs.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        builder.Host.UseSerilog();
        builder.Services.AddControllers();
        builder.Services.AddDbContext<MySchoolDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("Con")));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<MySchoolDbContext>()
            .AddDefaultTokenProviders();
        builder.Services.Configure<IdentityOptions>(options => options.User.RequireUniqueEmail = true);
        var loggerFactory = new SerilogLoggerFactory(Log.Logger);
        builder.Services.AddSingleton<ILoggerFactory>(loggerFactory);

        var app = builder.Build();

        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        app.ConfigureExceptionHandler(logger);

        // Seed the database
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<MySchoolDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            Seeder.SeedDataBase(roleManager, userManager, dbContext);
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MySchool.Api v1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
