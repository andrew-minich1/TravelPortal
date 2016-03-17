using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;
using TravelPortal.Data.Entities;

namespace TravelPortal.Data.Mappings
{
    internal class CountryMapping
    {
        public static void Map(EntityTypeBuilder<Country> b)
        {
            b.ToTable("COUNTRIES");
            b.HasKey(x => x.Id);

            b.Property(x => x.Name).HasColumnName("COUNTRY");
        }
    }
}
