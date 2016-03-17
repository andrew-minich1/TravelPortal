using System;
using TravelPortal.Data.Entities;
using TravelPortal.Services.Domain;
using TravelPortal.Services.Infrastructure;

namespace TravelPortal.Services.Mappers
{
    public class CountryMapper : IMapper<Country, CountryDomain>
    {
        public void ToDbEntity(CountryDomain domainEntity, Country dbEntity)
        {
            throw new NotImplementedException();
        }

        public Domain.CountryDomain ToDomainEntity(Country entity)
        {
            throw new NotImplementedException();
        }
    }
}
