using BooksWorld.Application.Mappings;
using BooksWorld.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BooksWorld.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<AuthorService>();
        services.AddScoped<BookService>();
        services.AddScoped<GenreService>();
        services.AddScoped<ReviewService>();
        services.AddScoped<OrderService>();
        services.AddScoped<AudiobookService>();
        services.AddScoped<EBookService>();
        services.AddScoped<PaperbookService>();

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddMappings();

        return services;
    }
}