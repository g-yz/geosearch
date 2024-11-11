using Microsoft.AspNetCore.Mvc;
using GeoSearch.Models;
using System.Collections.Generic;
using GeoSearch.Data;
using GeoSearch.Services;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace GeoSearch.Controllers;

public class PlaceController : Controller
{
    private readonly ILogger<PlaceController> _logger;
    private readonly HttpClientHelper _httpClient;

    private readonly string FoursquarePlaceDetailsApiUrl;
    private readonly string FoursquarePlaceImageApiUrl;
    private readonly string FoursquarePlaceTipsApiUrl;
    private readonly IFavoritesService _favoritesService;

    public PlaceController(ILogger<PlaceController> logger, HttpClientHelper httpClient, IFavoritesService FavoritesService)
    {
        _logger = logger;
        _httpClient = httpClient;
        _favoritesService = FavoritesService;
        var baseUrl = Environment.GetEnvironmentVariable("foursquare_apiurl");
        FoursquarePlaceDetailsApiUrl = baseUrl + "/{0}";
        FoursquarePlaceImageApiUrl = baseUrl + "/{0}/photos";
        FoursquarePlaceTipsApiUrl = baseUrl + "/{0}/tips";

    }

    [Route("Place/Details/{placeId}")]
    public async Task<ActionResult> Place(string placeId)
    {
        if (string.IsNullOrEmpty(placeId))
        {
            return RedirectToAction("Error");
        }
        
        var placeDetails = await GetPlaceDetailsFromApi(placeId);
        var placeTips = await GetPlaceTipsFromApi(placeId);
        var placeImages = await GetPlaceImagesFromApi(placeId);

        ViewBag.PlaceId = placeId;
        ViewBag.PlaceDetails = placeDetails;
        ViewBag.PlaceTips = placeTips;
        ViewBag.PlaceImages = placeImages;

        return View();
    }

    private async Task<FoursquarePlaceDetailsModel> GetPlaceDetailsFromApi(string placeId)
    {
        var formattedUrl = string.Format(FoursquarePlaceDetailsApiUrl, placeId);
        return await _httpClient.GetApiResponseAsync<FoursquarePlaceDetailsModel>(formattedUrl, Environment.GetEnvironmentVariable("foursquare_apikey"));
    }

    private async Task<FoursquarePlaceTipsModel> GetPlaceTipsFromApi(string placeId)
    {
        var formattedUrl = string.Format(FoursquarePlaceTipsApiUrl, placeId);
        return new FoursquarePlaceTipsModel() {
            Tips = await _httpClient.GetApiResponseAsync<List<FoursquareTip>>(formattedUrl, Environment.GetEnvironmentVariable("foursquare_apikey"))
        }; 
    }

    private async Task<FoursquarePlaceImagesModel> GetPlaceImagesFromApi(string placeId)
    {
        var formattedUrl = string.Format(FoursquarePlaceImageApiUrl, placeId);
        return new FoursquarePlaceImagesModel()
        {
            Images = await _httpClient.GetApiResponseAsync<List<PlaceImage>>(formattedUrl, Environment.GetEnvironmentVariable("foursquare_apikey"))
        };
    }


    [Route("Place/Favorites")]
    public async Task<ActionResult> FavoritePlace()
    {
        var favoritePlaces = await _favoritesService.GetAllAsync();

        return View(favoritePlaces);
    }

    [HttpPost]
    public async Task<ActionResult> AddAsFavorite(FavoritePlace model)
    {
        if (model != null)
        {
            await _favoritesService.AddAsync(model);
        }

        return RedirectToAction("FavoritePlace");
    }

    [HttpPost]
    public async Task<ActionResult> RemoveFavorite(string fsqId)
    {
        if (!string.IsNullOrEmpty(fsqId))
        {
            await _favoritesService.DeleteAsync(fsqId);
        }

        return RedirectToAction("FavoritePlace");
    }
}
