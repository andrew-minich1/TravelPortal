using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPortal.Services.Infrastructure
{
    public interface IMapper<DbEntity, DomainEntity>
    {
        DomainEntity ToDomainEntity(DbEntity entity);
        void ToDbEntity(DomainEntity domainEntity, DbEntity dbEntity);
    }
}
