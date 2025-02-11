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
    /// <summary>
    /// Configura as propriedades comuns a todas as entidades base, como chave primária e nome.
    /// Chama o método abstrato <see cref="AppendConfig(EntityTypeBuilder{T})"/> para configurações específicas da entidade.
    /// </summary>
    /// <param name="builder">Objeto <see cref="EntityTypeBuilder{T}"/> usado para configurar a entidade.</param>
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            // Chave primária
            builder.HasKey(b => b.Id);

            // Gera um GUID automaticamente no SQL Server
            builder.Property(g => g.Id)
            .HasDefaultValueSql("NEWID()"); 

            // Propriedade Name
            builder.Property(b => b.Name)
                   .HasColumnName("Name")
                   .HasMaxLength(100)
                   .IsRequired();

            AppendConfig(builder);
        }

        /// <summary>
        /// Método abstrato para definir configurações específicas de cada entidade concreta.
        /// Deve ser implementado pelas classes que herdam <see cref="BaseEntityConfiguration{T}"/>.
        /// </summary>
        /// <param name="builder">Objeto <see cref="EntityTypeBuilder{T}"/> usado para definir configurações adicionais.</param>
        protected abstract void AppendConfig(EntityTypeBuilder<T> builder);
    }
}
