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
        /// Nome do prêmio, como "Oscar" ou "Globo de Ouro".
        /// </summary>
        public string Name { get; set; }
    }
}
