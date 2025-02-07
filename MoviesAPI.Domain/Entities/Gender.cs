using MoviesAPI.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace MoviesAPI.Domain.Entities
{
    /// <summary>
    /// Representa um gênero cinematográfico, como terror, comédia ou ação.
    /// </summary>
    public class Gender : BaseEntity
    {
        /// <summary>
        /// Nome do gênero do filme.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Lista de filmes que pertencem a esse gênero.
        /// </summary>
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
