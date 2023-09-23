using SmartphoneTechAdvisor.HttpClients;
using SmartphoneTechAdvisor.Models;

namespace SmartphoneTechAdvisor.Services
{
    public class AdvisorService : IRootobject
    {
        private readonly IRootobject _rootObject;

        public AdvisorService(IRootobject rootObject)
        {
            _rootObject = rootObject;
        }

        public Task<List<Rootobject>> GetPhoneSpecsAsync(string phone)
        {
            throw new NotImplementedException();
        }
    }
}
