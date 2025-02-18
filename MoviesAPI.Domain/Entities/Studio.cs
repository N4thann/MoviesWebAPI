using MoviesAPI.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace MoviesAPI.Domain.Entities
{
    /// <summary>
    /// Representa um estúdio de cinema responsável pela produção de filmes.
    /// </summary>
    public class Studio : BaseEntity
    {
        public Studio() 
        {
            Movies = new List<Movie>();
        } 
        /// <summary>
        /// Descrição sobre o estúdio, incluindo sua história ou especialização.
        /// </summary>
        public string Description { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
