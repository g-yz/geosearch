using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GeoSearch.Models;

namespace GeoSearch.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClientHelper _httpClient;
    private readonly IConfiguration _configuration;
    const int LIMIT = 25;
    private readonly string FoursquareSearchApiUrl;

    public HomeController(ILogger<HomeController> logger, HttpClientHelper httpClient, IConfiguration configuration)
    {
        _logger = logger;
        _httpClient = httpClient;
        _configuration = configuration;
        FoursquareSearchApiUrl = _configuration.GetConnectionString("foursquare_apiurl") + "/search?";
    }

    public IActionResult Index()
    {
        var model = new SearchModel
        {
            Latitude = "51.505",
            Longitude = "-0.09",
        };
        return RedirectToAction("FindLocations", "Home", model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [Route("Home/FindLocations")]
    public async Task<ActionResult> FindLocations(SearchModel model)
    {
        if (!string.IsNullOrEmpty(model.Location) || !string.IsNullOrEmpty(model.Latitude))
        {
            var result = await GetPlacesFromApi(model, LIMIT);
            if (result != null && result.Results.Count > 0)
            {
                model.Response = result;
            }
            else
            {
                ViewBag.ErrorMessage = "No locations found.";
            }
        }
        else
        {
            ViewBag.ErrorMessage = "Please enter a location to search.";
        }

        return View("Index", model);
    }

    private async Task<FoursquareResponse> GetPlacesFromApi(string location, int limit)
    {
        var formattedUrl = string.Format(FoursquareSearchApiUrl, location, limit);
        return await _httpClient.GetApiResponseAsync<FoursquareResponse>(formattedUrl, _configuration.GetConnectionString("foursquare_apikey"));
    }
    private async Task<FoursquareResponse> GetPlacesFromApi(SearchModel model, int limit)
    {
        var formattedUrl = string.Format(FoursquareSearchApiUrl, limit);
        if (!string.IsNullOrEmpty(model.Location))
        {
            formattedUrl = $"{formattedUrl}&query={model.Location}";
        }
        if (!string.IsNullOrEmpty(model.Latitude) && !string.IsNullOrEmpty(model.Longitude))
        {
            formattedUrl = $"{formattedUrl}&ll={model.Latitude},{model.Longitude}";
        }
        if (!string.IsNullOrEmpty(model.Limit))
        {
            formattedUrl = $"{formattedUrl}&limit={model.Limit}";
        }

        return await _httpClient.GetApiResponseAsync<FoursquareResponse>(formattedUrl, _configuration.GetConnectionString("foursquare_apikey"));
    }
}
