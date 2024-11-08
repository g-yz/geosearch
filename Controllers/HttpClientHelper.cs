using RestSharp;

namespace GeoSearch.Controllers;

public class HttpClientHelper
{
    private readonly RestClient _client;

    public HttpClientHelper()
    {
        _client = new RestClient();
    }

    public async Task<T> GetApiResponseAsync<T>(string url, string apiKey) where T : new()
    {
        var result = new T();
        var request = new RestRequest(url, Method.Get);
        request.AddHeader("Authorization", apiKey);

        try
        {
            var response = await _client.ExecuteAsync<T>(request);

            if (response.IsSuccessful && response.Data != null)
            {
                result = response.Data;
            }
        }
        catch (Exception ex)
        {
            return result;
        }

        return result;
    }
}
