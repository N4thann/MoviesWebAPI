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
    public class MovieConfiguration : BaseEntityConfiguration<Movie>
    {
        protected override void AppendConfig(EntityTypeBuilder<Movie> builder)
        {
            // Nome da tabela
            builder.ToTable("Movie");

            // Configuração de propriedades
            builder.Property(m => m.Synopsis)
                   .HasColumnName("Synopsis")
                   .HasMaxLength(1000);

            builder.Property(m => m.ReleaseYear)
                   .HasColumnName("ReleaseYear")
                   .IsRequired();

            builder.Property(m => m.Runtime)
                   .HasColumnName("Runtime")
                   .IsRequired();

            builder.Property(m => m.TotalRatings)
                   .HasColumnName("TotalRatings")
                   .HasDefaultValue(0);

            builder.Property(m => m.SumOfRatings)
                   .HasColumnName("SumOfRatings")
                   .HasDefaultValue(0);

            builder.Property(m => m.Rating)
                   .HasColumnName("Rating")
                   .HasComputedColumnSql("CASE WHEN TotalRatings > 0 THEN CAST(SumOfRatings AS FLOAT) / TotalRatings ELSE 0 END");

            builder.Property(m => m.Trailer)
                   .HasColumnName("Trailer")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(m => m.NationalityId)
                   .HasColumnName("NationalityId")
                   .IsRequired();

            builder.Property(m => m.StudioId)
                   .HasColumnName("StudioId")
                   .IsRequired();

            builder.Property(m => m.DirectorId)
                   .HasColumnName("DirectorId")
                   .IsRequired();

            //"imgBuilder" é apenas um nome para o sub-builder que o método OwnsMany() fornece.
            //Esse sub-builder nos permite configurar a tabela MovieImages dentro da MovieConfiguration.
            // Um Filme tem muitas Imagens
            builder.OwnsMany(m => m.Images, imgBuilder =>
            {
                imgBuilder.ToTable("MovieImages");
                imgBuilder.WithOwner().HasForeignKey("MovieId");
                imgBuilder.Property<string>("ImageUrl").HasColumnName("ImageUrl").HasMaxLength(500);
            });

            // Um Filme tem muitos Prêmios
            builder.HasMany(m => m.Awards)
                   .WithOne()
                   .HasForeignKey("MovieId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
 