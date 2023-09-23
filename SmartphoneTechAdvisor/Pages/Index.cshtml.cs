using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SmartphoneTechAdvisor.Models;

namespace SmartphoneTechAdvisor.Pages
{

    public class IndexModel : PageModel
    {
        private const string ApiBaseUrl = "https://smarttechadvisor.azurewebsites.net/api/";

        [BindProperty] 
        public string? PhoneName1 { get; set; }

        [BindProperty]
        public string? PhoneName2 { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnPost()
        {
            _logger.LogInformation($"OnPost called {PhoneName1}, {PhoneName2}");

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ApiBaseUrl);
            try
            {
                var response = await httpClient.GetAsync(PhoneName1);
                var response2 = await httpClient.GetAsync(PhoneName2);
                string responseDataJson = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<Rootobject>(responseDataJson);

                string responseDataJson2 = await response2.Content.ReadAsStringAsync();
                var responseData2 = JsonConvert.DeserializeObject<Rootobject>(responseDataJson2);

                var techSpecData = new[] { responseData, responseData2 };
                var serializedData = JsonConvert.SerializeObject(techSpecData);
                TempData["TechSpecData"] = serializedData;

                return RedirectToPage("CompareTable");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HTTP request error: {e.Message}");
            }
            
            return RedirectToPage("CompareTable");
        }
    }
}