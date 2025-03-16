using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesAPI.Domain.Entities;

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

            // Ignorar as chaves estrangeiras no EF Core (deixar apenas para o MongoDB)
            builder.Ignore(m => m.NationalityId);
            builder.Ignore(m => m.StudioId);
            builder.Ignore(m => m.DirectorId);
            builder.Ignore(m => m.GenderId);

            // Configuração dos relacionamentos sem precisar das chaves estrangeiras explícitas
            builder.HasOne<Nationality>()
                   .WithMany()
                   .HasForeignKey("NationalityId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Studio>()
                   .WithMany()
                   .HasForeignKey("StudioId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Director>()
                   .WithMany()
                   .HasForeignKey("DirectorId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Gender>()
                   .WithMany()
                   .HasForeignKey("GenderId")
                   .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento 1:N entre Movie e MovieImage
            builder.HasMany(m => m.Images)
                   .WithOne()
                   .HasForeignKey("MovieId")
                   .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento 1:N entre Movie e Awards
            builder.HasMany(m => m.Awards)
                   .WithOne()
                   .HasForeignKey("MovieId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
