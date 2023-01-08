using Microsoft.EntityFrameworkCore; // Use MySql
using Microsoft.Extensions.DependencyInjection; // IServiceCollection
using Microsoft.Extensions.Logging; // LogLevel

namespace ProofOfConcepts.Shared;
public static class SakilaContextContextExtensions
{
    /// <summary>
    /// Adds NorthwindContext to the specified IServiceCollection. Uses the MySql database provider.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connectionString">Set to override the default.</param>
    /// <returns>An IServiceCollection that can be used to add more services.</returns>
    public static IServiceCollection AddSakilaContext(this IServiceCollection services,
     string connectionString = "server=localhost;user=root;password=Gold$gym45;database=sakila")
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

        services.AddDbContext<SakilaContext>(dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );
        return services;
    }
}