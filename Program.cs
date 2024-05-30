using System;
using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using Tashgheel_Api.Extensions;
using Tashgheel_Api.Helpers;
using ConfigurationProvider = Tashgheel_Api.Helpers.ConfigurationProvider;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder.WithOrigins("http://localhost:8000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        options.SerializerSettings.Converters.Add(new IsoDateTimeConverter
            { DateTimeStyles = DateTimeStyles.AssumeUniversal });
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => { options.OperationFilter<PascalCaseQueryParameterFilter>(); });
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

// Add LinkedIn authentication

builder.Services.AddAuthentication()
    .AddLinkedIn(options =>
    {
        options.ClientId = builder.Configuration["Authentication:LinkedIn:ClientId"];
        options.ClientSecret = builder.Configuration["Authentication:LinkedIn:ClientSecret"];
    });

IConfiguration configuration = builder.Configuration;
        ConfigurationProvider.Configuration = configuration;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            options.RoutePrefix = string.Empty;
            options.DocExpansion(DocExpansion.None);
        });
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCors("AllowSpecificOrigins");
        app.UseCors("AllowLocalhost");

       // app.UseMiddleware<CustomUnauthorizedMiddleware>();
        //app.UseMiddleware<CustomPayloadTooLargeMiddleware>();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseStaticFiles();
        app.MapControllers();
        app.MapHup();
        app.MapControllers();





        app.Run();

        app.Run();
