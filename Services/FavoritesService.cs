using GeoSearch.Data;
using GeoSearch.Repositories;

namespace GeoSearch.Services;

public interface IFavoritesService
{
    Task<bool> AddAsync(FavoritePlace favoritePlace);
    Task<IEnumerable<FavoritePlace>> GetAllAsync();
    Task<bool> DeleteAsync(string fsqId);
}

public class FavoritesService : IFavoritesService
{
    public readonly IFavoriteRepository _favoriteRepository;
    public FavoritesService(IFavoriteRepository favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }

    public async Task<bool> AddAsync(FavoritePlace favoritePlace)
    {
        return await _favoriteRepository.CreateAsync(favoritePlace);
    }

    public async Task<bool> DeleteAsync(string fsqId)
    {
        return await _favoriteRepository.DeleteAsync(fsqId);
    }

    public async Task<IEnumerable<FavoritePlace>> GetAllAsync()
    {
        return await _favoriteRepository.GetAllAsync();
    }
}
