﻿using System.Net;
using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace API.API.Extensions
{
    static public class ConfigureExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler<T>(this WebApplication application, ILogger<T> logger)
        {
            application.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError(contextFeature.Error.Message);
                        await context.Response.WriteAsJsonAsync(JsonSerializer.Serialize(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Title = "Hata Alındı"
                        }, new JsonSerializerOptions
                        {
                            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                            WriteIndented = true // JSON'ı daha okunabilir hale getirmek için (isteğe bağlı)
                        }));
                    }
                });
            });
        }
    }
}
