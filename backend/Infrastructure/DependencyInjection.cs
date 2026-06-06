using Application.Interfaces;
using Domain.Entities.Identity;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                npgsql => npgsql.EnableRetryOnFailure()
            ));

        services
            .AddIdentity<AppUser, AppRole>(options =>
            {
                options.Stores.MaxLengthForKeys = 128;

                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IBookingDbContext, AppDbContext>();
        //services.AddSingleton<IImageService, ImageService>();
        //services.AddSingleton<IEmailService, GmailEmailService>();
        services.AddTransient<IDbInicializer, DbInitializer>();
        services.AddTransient<IScopeCoveredDbInicializer, ScopeCoveredDbInicializer>();
        services.AddTransient<ICleanDataSeeder, CleanDataSeeder>();
        services.AddTransient<IGeneratedDataSeeder, GeneratedDataSeeder>();
        services.AddTransient<IAggregateSeeder, AggregateSeeder>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();

        services.AddScoped<Application.Interfaces.ITokenService, Services.TokenService>();

        services.AddTransient<IDbInicializer, DbInitializer>();
        services.AddTransient<IScopeCoveredDbInicializer, ScopeCoveredDbInicializer>();

        return services;
    }
}
