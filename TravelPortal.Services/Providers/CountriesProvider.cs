using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TravelPortal.Data.Entities;
using TravelPortal.Data.Infrastructure;
using TravelPortal.Services.Domain;
using TravelPortal.Services.Infrastructure;
using TravelPortal.Services.Mappers;

namespace TravelPortal.Services.Providers
{
    public class CountriesProvider
    {
        private readonly CountryMapper _countryMapper;
        private readonly IUnitOfWork _uow;

        public CountriesProvider(IUnitOfWork uow, CountryMapper countryMapper)
        {
            _uow = uow;
            _countryMapper = countryMapper;
        }

        public void Initialize()
        {
            _uow.Initialize();
        }

        public IQueryable<CountryDomain> GetAll()
        {
            return _uow.Entity<Country>().Select(x=>_countryMapper.ToDomainEntity(x));
        }
    }
}
