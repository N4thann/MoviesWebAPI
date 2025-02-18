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

        /// <summary>
        /// Chave estrangeira que referencia o filme premiado.
        /// </summary>
        public Guid MovieId { get; set; }

        /// <summary>
        /// Chave estrangeira que referencia o Diretor premiado.
        /// </summary>
        public Guid DirectorId { get; set; }
    }
}
/*Existe muitos benefícios como o lazy loading ao incluir o "public virtual Movie Movie { get; set; }"
 * junto com MovieId. Teriamos o objeto Movie completo e o entity framework poderia fazer consultas e leituras
 * automáticas. Não vamos utilizar pois as consultas do sistemas serão feitas no MongoDb e este não
 * não faz joins automaticamente, então essa propriedade nunca seria preenchida. Pode ser utilizado 
 * o [BsonIgnore] para ser ignorado pelo MongoDb e não ter conflito ao utilizar um banco SQL e NoSql.
 */
