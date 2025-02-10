using MoviesAPI.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAPI.Domain.Entities
{
    /// <summary>
    /// Representa um prêmio recebido por um filme.
    /// </summary>
    public class Award : BaseEntity
    {
        /// <summary>
        /// Ano da premiação
        /// </summary>
        public int ReleaseYear { get; set; }
    }
}
