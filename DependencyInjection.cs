using GeoSearch.Controllers;
using GeoSearch.Data;
using GeoSearch.Repositories;
using GeoSearch.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GeoSearch;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<HttpClientHelper>();
        services.AddScoped<IFavoritesService, FavoritesService>();
        services.AddScoped<IFavoriteRepository, FavoriteRepository>();
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("database")));
        return services;
    }
}
