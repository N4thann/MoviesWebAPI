using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAPI.Domain.Entities
{
    public class MovieImage
    {
        /// <summary>
        /// Identificador único
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Identificador do filme ao qual a imagem pertence.
        /// </summary>
        public Guid MovieId { get; set; }

        /// <summary>
        /// URL da imagem.
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
