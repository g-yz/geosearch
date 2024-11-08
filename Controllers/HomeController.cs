using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GeoSearch.Models;

namespace GeoSearch.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClientHelper _httpClient;
    const int LIMIT = 5;
    private readonly string FoursquareSearchApiUrl;

    public HomeController(ILogger<HomeController> logger, HttpClientHelper httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
        FoursquareSearchApiUrl = Environment.GetEnvironmentVariable("foursquare_apiurl") + "/search?query={0}&limit={1}";
    }

    public IActionResult Index()
    {
        var model = new SearchModel();
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public async Task<ActionResult> FindLocations(SearchModel model)
    {
        if (!string.IsNullOrEmpty(model.Location))
        {
            var result = await GetPlacesFromApi(model.Location, LIMIT);
            if (result != null && result.Results.Count > 0)
            {
                model.Response = result;
            }
            else
            {
                ViewBag.ErrorMessage = "No locations found.";
            }
        }

        return View("Index", model);
    }

    private async Task<FoursquareResponse> GetPlacesFromApi(string location, int limit)
    {
        var formattedUrl = string.Format(FoursquareSearchApiUrl, location, limit);
        return await _httpClient.GetApiResponseAsync<FoursquareResponse>(formattedUrl, Environment.GetEnvironmentVariable("foursquare_apikey"));
    }
}
