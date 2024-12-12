using BooksWorld.Application;
using BooksWorld.Persistance;

namespace BooksWorld.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApplication()
                        .AddPersistance();

        builder.Services.AddControllersWithViews();

        builder.Services.AddCors(options => 
            options.AddDefaultPolicy(builderOptions =>
            {
                builderOptions.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
            })
        );

        var app = builder.Build();
        
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseStaticFiles();
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors();

        app.UseAuthorization();
        app.UseAuthentication();

        app.MapControllers();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}