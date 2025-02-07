using MoviesAPI.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace MoviesAPI.Domain.Entities
{
    /// <summary>
    /// Representa um diretor de filmes.
    /// </summary>
    public class Director : BaseEntity
    {
        /// <summary>
        /// Nome do diretor.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Idade do diretor. Esse campo será atualizado automaticamente com base na data de aniversário.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Data de nascimento do diretor.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// URL da imagem do diretor.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Identificador da nacionalidade do diretor.
        /// </summary>
        public Guid NationalityId { get; set; }

        /// <summary>
        /// Lista de prêmios que o diretor recebeu ao longo da carreira.
        /// </summary>
        public virtual ICollection<Award> Awards { get; set; }

        /// <summary>
        /// Lista de filmes dirigidos pelo diretor.
        /// </summary>
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
