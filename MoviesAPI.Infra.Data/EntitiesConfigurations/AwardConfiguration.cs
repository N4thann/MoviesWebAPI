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
    public class AwardConfiguration : BaseEntityConfiguration<Award>
    {
        protected override void AppendConfig(EntityTypeBuilder<Award> builder)
        {
            // Nome da tabela
            builder.ToTable("Award");

            builder.Property(m => m.ReleaseYear)
                   .HasColumnName("ReleaseYear")
                   .IsRequired();
        }
    }
}
