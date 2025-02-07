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
        /// <summary>
        /// Nome do estúdio de cinema.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição sobre o estúdio, incluindo sua história ou especialização.
        /// </summary>
        public string Description { get; set; }
    }
}
