﻿using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using MySchool.Models.Entities;

namespace MySchoolApp.Extensions
{
    public static class ExceptionHandlerExtension
    {
        internal static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger<Program> logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError(contextFeature.Error, "Something went wrong"); // Log the error to Serilog

                        var errorDetails = new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error"
                        };
                        var jsonErrorDetails = JsonSerializer.Serialize(errorDetails);
                        await context.Response.WriteAsync(jsonErrorDetails);
                    }
                });
            });
        }
    }
}
