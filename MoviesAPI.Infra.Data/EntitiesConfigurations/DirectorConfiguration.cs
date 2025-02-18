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
    public class DirectorConfiguration : BaseEntityConfiguration<Director>
    {
        protected override void AppendConfig(EntityTypeBuilder<Director> builder)
        {
            builder.ToTable("Director");

            builder.Property(d => d.Age)
                .HasColumnName("Age")
                .IsRequired();

            builder.Property(d => d.Birthday)
                .HasColumnName("Birthday")
                .IsRequired();

            builder.Property(d => d.Image).
                HasColumnName("Image")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(m => m.NationalityId)
                   .HasColumnName("NationalityId")
                   .IsRequired();

            // Um Diretor tem muitos Prêmios
            builder.HasMany(m => m.Awards)
                   .WithOne()
                   .HasForeignKey("DirectorId")
                   .OnDelete(DeleteBehavior.Cascade);

            // Um Diretor tem muitos Filmes
            builder.HasMany(m => m.Movies)
                   .WithOne()
                   .HasForeignKey("DirectorId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
