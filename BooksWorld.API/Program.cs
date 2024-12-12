using BooksWorld.Application;
using BooksWorld.Persistance;

namespace BooksWorld.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddPresentation()
                        .AddApplication()
                        .AddPersistance();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(options => options.AllowAnyOrigin());

        app.UseExceptionHandler("/error");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}