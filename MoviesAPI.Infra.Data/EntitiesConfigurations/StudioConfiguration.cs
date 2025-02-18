using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesAPI.Domain.Entities;

namespace MoviesAPI.Infra.Data.EntitiesConfigurations
{
    public class StudioConfiguration : BaseEntityConfiguration<Studio>
    {
        protected override void AppendConfig(EntityTypeBuilder<Studio> builder)
        {
            // Nome da tabela
            builder.ToTable("Studio");

            builder.Property(m => m.Description)
               .HasColumnName("Description")
               .HasMaxLength(1000);

            // Um Studio tem muitos Filmes
            builder.HasMany(m => m.Movies)
                   .WithOne()
                   .HasForeignKey("StudioId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
