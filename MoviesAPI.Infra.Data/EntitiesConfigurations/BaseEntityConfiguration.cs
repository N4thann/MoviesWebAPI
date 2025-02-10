using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesAPI.Domain.SeedWork;
using MoviesAPI.Domain.Entities;
using System.Reflection.Emit;

namespace MoviesAPI.Infra.Data.EntitiesConfigurations
{
    //Essa configuração segue o príncipio do DRY, pegando as configurações comuns
    //entre as 3 entidades e centralizando aqui. Nas outras entityconfigurations utilizamos
    //o método AppendConfig, visto que as outras configurações herdam essa
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            // Chave primária
            builder.HasKey(b => b.Id);

            builder.Property(g => g.Id)
            .HasDefaultValueSql("NEWID()"); // Gera um GUID automaticamente no SQL Server

            // Propriedade Name
            builder.Property(b => b.Name)
                   .HasColumnName("Name")
                   .HasMaxLength(100)
                   .IsRequired();

            AppendConfig(builder);
        }

        protected abstract void AppendConfig(EntityTypeBuilder<T> builder);
    }
}
