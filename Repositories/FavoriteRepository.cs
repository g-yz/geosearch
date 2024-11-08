using GeoSearch.Data;
using Microsoft.EntityFrameworkCore;

namespace GeoSearch.Repositories;

public interface IFavoriteRepository
{
    Task<IEnumerable<FavoritePlace>> GetAllAsync();
    Task<bool> CreateAsync(FavoritePlace place);
}


public class FavoriteRepository : IFavoriteRepository
{
    public readonly ApplicationDbContext _context;
    public FavoriteRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateAsync(FavoritePlace place)
    {
        var existingPlace = await _context.FavoritePlaces.FirstOrDefaultAsync(fp => fp.FsqId == place.FsqId);

        if (existingPlace != null) return false;

        _context.FavoritePlaces.Add(place);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<IEnumerable<FavoritePlace>> GetAllAsync()
    {
        return await _context.FavoritePlaces.ToListAsync();
    }
}
