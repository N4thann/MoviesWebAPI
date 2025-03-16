using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Domain.Entities;

namespace MoviesAPI.Infra.Data.EntitiesConfigurations
{
    public class MovieImageConfiguration : IEntityTypeConfiguration<MovieImage>
    {
        public void Configure(EntityTypeBuilder<MovieImage> builder)
        {
            builder.ToTable("MovieImages");

            builder.HasKey(mi => mi.Id);

            builder.Property(mi => mi.Id)
                .HasDefaultValueSql("NEWID()");

            builder.Property(mi => mi.ImageUrl)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(mi => mi.MovieId)
                .IsRequired();
        }
    }
}
