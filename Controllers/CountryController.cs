using Microsoft.AspNetCore.Mvc;

namespace country.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CountryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("names")]
        public async Task<IActionResult> GetCountryNames()
        {
            var httpClient = _httpClientFactory.CreateClient();

            // Call the CountriesNow API
            var response = await httpClient.GetFromJsonAsync<CountryIsoResponse>(
                "https://countriesnow.space/api/v0.1/countries/iso");

            if (response?.Data == null || response.Error)
            {
                return BadRequest("Unable to fetch country data.");
            }

            // Extract only the 'Name' property from each country object
            var countryNames = response.Data.Select(c => c.Name).ToList();

            return Ok(countryNames);
        }

    }
}