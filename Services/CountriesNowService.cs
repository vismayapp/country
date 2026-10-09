using country;
using System.Net.Http.Json;

public class CountriesNowService
{
    private readonly HttpClient _httpClient;

    public CountriesNowService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://countriesnow.space/api/v0.1/");
    }

    public async Task<List<CountryIso>?> GetCountriesAndCodesAsync()
    {
        // The endpoint from documentation is /countries/iso
        var response = await _httpClient.GetFromJsonAsync<CountryIsoResponse>("countries/iso");
        return response?.Data;
    }
}