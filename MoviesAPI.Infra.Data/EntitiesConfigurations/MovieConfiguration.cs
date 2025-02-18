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

            //É boa prática definir explicitamente os relacionamentos
            //com .HasOne(), garantindo a integridade referencial.
            //Isso evita que registros dependentes sejam deletados acidentalmente.
            builder.HasOne<Nationality>()
               .WithMany()
               .HasForeignKey(m => m.NationalityId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Studio>()
                   .WithMany()
                   .HasForeignKey(m => m.StudioId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Director>()
                   .WithMany()
                   .HasForeignKey(m => m.DirectorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Gender>()
                   .WithMany()
                   .HasForeignKey(m => m.DirectorId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento 1:N entre Movie e MovieImage
            builder.HasMany<MovieImage>()
                   .WithOne()
                   .HasForeignKey(mi => mi.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Um Filme tem muitos Prêmios
            builder.HasMany(m => m.Awards)
                   .WithOne()
                   .HasForeignKey("MovieId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
 