using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAPI.Infra.Data.EntitiesConfigurations
{
    public class NationalityConfiguration : BaseEntityConfiguration<Nationality>
    {
        protected override void AppendConfig(EntityTypeBuilder<Nationality> builder)
        {
            builder.ToTable("Nationality");
        }
    }
}
