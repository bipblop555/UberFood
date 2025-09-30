using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UberFood.Core.Context;

namespace UberFood.Api.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
    {

        //services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        //services.Configure<CorsSettings>(configuration.GetSection(CorsSettings.SectionName));

        // Database configuration
        // Retrieve the connection string and ensure it exists
        var connectionString = "Server=localhost;Database=EatDomicile;TrustServerCertificate=True;Trusted_Connection=True;";

        // Configure Entity Framework with In-Memory database for development/testing
        // Référence MS Doc: https://learn.microsoft.com/en-us/ef/core/providers/in-memory/
        services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString));

        return services;
    }

    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        // API services configuration
        // Configure controllers with custom options to preserve async method naming
        // Référence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/actions
        services.AddControllers(options =>
        {
            // Keep async suffix in action names for clarity (e.g., GetBooksAsync)
            options.SuppressAsyncSuffixInActionNames = false;
        });

        // OpenAPI configuration for API documentation
        // Enables automatic API documentation generation and integration with Scalar
        // Référence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();

        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // Health checks configuration
        // Provides endpoints to monitor application and database health
        // Référence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks
        services.AddHealthChecks();
        // Add database connectivity check using Entity Framework context

        // Response caching services
        // Enables HTTP response caching to improve performance for cacheable responses
        // Référence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/performance/caching/middleware
        services.AddResponseCaching();

        // Response compression configuration
        // Reduces response size by compressing HTTP responses
        // Référence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/performance/response-compression
        services.AddResponseCompression(options =>
        {
            // Enable compression for HTTPS requests (disabled by default for security)
            options.EnableForHttps = true;
            // Add Brotli compression provider (more efficient than Gzip)
            // Référence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/performance/response-compression#brotli-and-gzip-compression-providers
            options.Providers.Add<BrotliCompressionProvider>();
            // Add Gzip compression provider (widely supported fallback)
            options.Providers.Add<GzipCompressionProvider>();
        });

        return services;
    }
}
