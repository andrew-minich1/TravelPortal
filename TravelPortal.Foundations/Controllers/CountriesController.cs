using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TravelPortal.Services.Domain;
using TravelPortal.Services.Providers;

namespace TravelPortal.Foundations.Controllers
{
    public class CountriesController : ApiController
    {
        private readonly CountriesProvider _countriesProvider;

        public CountriesController(CountriesProvider countriesProvider)
        {
            _countriesProvider = countriesProvider;
        }

        public CountriesController()
        {
            
        }

        public IEnumerable<CountryDomain> Get()
        {
            return _countriesProvider.GetAll().ToList();
        }

        public string Get(int id)
        {
            return "value";
        }

        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
