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
    public class GenderConfiguration : BaseEntityConfiguration<Gender>
    {
        protected override void AppendConfig(EntityTypeBuilder<Gender> builder)
        {
            // Nome da tabela
            builder.ToTable("Gender");

            builder.HasMany(g => g.Movies)
                   .WithOne()
                   .HasForeignKey("GenderId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
