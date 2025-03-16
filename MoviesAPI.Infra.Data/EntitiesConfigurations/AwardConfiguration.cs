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

            builder.Ignore(m => m.MovieId);
            builder.Ignore(m => m.DirectorId);

            builder.HasOne<Movie>()
                   .WithMany(m => m.Awards)
                   .HasForeignKey(a => a.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);// Se um filme for deletado, todos os prêmios associados também serão deletados.

            builder.HasOne<Director>()
                   .WithMany()
                   .HasForeignKey(a => a.DirectorId)
                   .OnDelete(DeleteBehavior.Restrict);//Impede que um diretor seja deletado se houver prêmios vinculados a ele.
        }
    }
}
/*Já que não foi adicionado a propriedade de navegação public virtual Movie Movie { get; set; } na entidade Award, 
 * a configuração correta no Fluent API será utilizar essas duas últimas configurações com HasOne, assim mapeamos
 * para as listas que estão presente nas outras entidade. Não utilizamos esse mapeamento "public virtual Movie Movie { get; set; }"
 * pois trabalharemos com MongoDb e para simplificar a entidade para a leitura decidimos não utilizar.
 */
