using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SmartphoneTechAdvisor.HttpClients;
using SmartphoneTechAdvisor.Models;

namespace SmartphoneTechAdvisor.Pages
{
    public class CompareTableModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public List<Rootobject>? techspec_object { get; set; } = new();

        public void OnGet()
        {
            var serializedData = TempData["TechSpecData"] as string ?? throw new Exception("Null data.");
            var techSpecData = JsonConvert.DeserializeObject<Rootobject[]>(serializedData);

            techspec_object = techSpecData == null ? throw new Exception("Null data.") : techSpecData.ToList();

            Console.WriteLine(techspec_object?[0].name);
        }
    }
}
