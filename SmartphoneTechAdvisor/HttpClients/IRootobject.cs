using SmartphoneTechAdvisor.Models;
using Refit;

namespace SmartphoneTechAdvisor.HttpClients
{
    public interface IRootobject
    {
        [Get("/{phone}")]
        Task<List<Rootobject>> GetPhoneSpecsAsync(string phone);
    }
}
