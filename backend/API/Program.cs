using API.Middleware;
using Application;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

//using Microsoft.OpenApi;
using Serilog;
using System.Reflection;
using System.Text;

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
        .AddJsonFile("appsettings.Local.json", optional: true)
        .AddEnvironmentVariables()
        .Build())
    .Enrich.FromLogContext()
    .CreateLogger();

try
{
    Log.Information("Starting BookingClone API");

    var builder = WebApplication.CreateBuilder(args);
    builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);
    builder.Host.UseSerilog();

    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();

    var jwtKey = builder.Configuration["Jwt:Key"]
        ?? throw new InvalidOperationException("Jwt:Key is not configured");
    Console.WriteLine("---------"+builder.Configuration["Jwt:Key"]);

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                ValidateIssuer = false,
                //ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidateAudience = false,
                //ValidAudience = builder.Configuration["Jwt:Audience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });

    //builder.Services.AddAuthorization();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    

    var frontendOrigins = (builder.Configuration["Frontend:Url"] ?? "http://localhost:5173")
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("FrontendPolicy", policy =>
            policy.WithOrigins(frontendOrigins)
                  .AllowAnyHeader()
                  .AllowAnyMethod());
    });

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
    app.UseSerilogRequestLogging();
    app.UseCors("FrontendPolicy");
    //app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    await app.Services.GetRequiredService<IScopeCoveredDbInicializer>().InitializeAsync();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
