using UberFood.Core.Context;
using UberFood.Api.Extensions;
using UberFood.Api.Seeds;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

ConfigureServices(builder);


var app = builder.Build();

await InitializeDatabaseAsync(app);

// Configure the HTTP request pipeline
// R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware
ConfigurePipeline(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfigureServices(WebApplicationBuilder builder)
{
    // Add services using extension methods for better organization
    builder.Services.AddDbContextServices(builder.Configuration);
    builder.Services.AddApiServices();
    builder.Services.AddInfrastructureServices();

    // Authentication (JWT)
    // R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/configure-jwt-bearer-authentication
}

// <summary>
// Initializes the database using Entity Framework Core.
// R�f�rence MS Doc: https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration
// </summary>
// <param name="app">The web application instance</param>
static async Task InitializeDatabaseAsync(WebApplication app)
{
    // R�f�rence MS Doc: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-scope
    using var scope = app.Services.CreateScope();

    try
    {
        // R�f�rence MS Doc: https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/#dbcontext-in-dependency-injection-for-aspnet-core
        var context = scope.ServiceProvider.GetRequiredService<DataContext>();
        await context.Database.EnsureCreatedAsync();

        /// <------------------ SEEDER --------------------> //

        //var seeder = new Seeder(context);
        //await seeder.SeedDataAsync();

        // R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("Database initialized successfully.");
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while creating the database.");
        throw;
    }
}

// <summary>
// Configures the HTTP request pipeline with middleware.
// R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware
// </summary>
// <param name="app">The web application instance</param>
static void ConfigurePipeline(WebApplication app)
{
    // Exception handling (should be first)
    // R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        // R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger
        app.MapOpenApi();
    }
    else
    {
        // R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling#exception-handler-page
        app.UseExceptionHandler("/Error");
        // R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/security/enforcing-ssl#http-strict-transport-security-protocol-hsts
        app.UseHsts();
    }

    // Security headers
    // R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/security/enforcing-ssl
    app.UseHttpsRedirection();

    // Response compression (early in pipeline)
    // R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/performance/response-compression
    app.UseResponseCompression();

    // CORS (before authentication)
    // R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/security/cors
    app.UseCors();

    // Authentication & Authorization
    // R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/security/authentication
    app.UseAuthentication();
    // R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/security/authorization/introduction
    app.UseAuthorization();

    // Response caching
    // R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/performance/caching/middleware
    app.UseResponseCaching();

    // Health checks
    // R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks
    app.MapHealthChecks("/health").AllowAnonymous();

    // API endpoints
    // R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/routing
    app.MapControllers();

    // Uncomment when ready to use minimal API endpoints
    // R�f�rence MS Doc: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis
    // app.MapBookStoreEndpoints();
}