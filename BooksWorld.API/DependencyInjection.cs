using BooksWorld.Application.Mappings;
using BooksWorld.Domain.Models.User;
using BooksWorld.Persistance.DataProviders.PostgreSql;

namespace BooksWorld.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddSwaggerGen();

        services.AddMappings();

        services.AddHttpContextAccessor();

        services.AddEndpointsApiExplorer();

        services.AddControllers();

        services.AddCors();
 
        return services;
    }
}
