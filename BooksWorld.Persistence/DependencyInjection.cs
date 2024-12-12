using BooksWorld.Domain.Interfaces;
using BooksWorld.Persistance.DataProviders.PostgreSql;
using BooksWorld.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BooksWorld.Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IAudiobookRepository, AudiobookRepository>();
        services.AddScoped<IEBookRepository, EBookRepository>();
        services.AddScoped<IPaperbookRepository, PaperbookRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(Constant.DbConnectionString));

        return services;
    }
}
