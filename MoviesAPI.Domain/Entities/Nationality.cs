using MoviesAPI.Domain.SeedWork;

namespace MoviesAPI.Domain.Entities
{
    /// <summary>
    /// Representa a nacionalidade de uma pessoa ou entidade no sistema.
    /// </summary>
    public class Nationality : BaseEntity
    {
        /// <summary>
        /// Nome do País de origem.
        /// </summary>
        public string Name { get; set; }
    }
}
