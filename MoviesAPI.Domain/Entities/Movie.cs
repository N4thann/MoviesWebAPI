using MoviesAPI.Domain.SeedWork;

namespace MoviesAPI.Domain.Entities
{
    /// <summary>
    /// Representa um filme com detalhes como título, sinopse, ano de lançamento, duração, avaliações e premiações associadas.
    /// </summary>
    public class Movie : BaseEntity
    {
        public Movie() 
        {
            Images = new List<string>();
            Awards = new List<Award>();           
        }
        /// <summary>
        /// Sinopse do filme, contendo um resumo da história.
        /// </summary>
        public string Synopsis { get; set; }

        /// <summary>
        /// Ano de lançamento do filme.
        /// </summary>
        public int ReleaseYear { get; set; }

        /// <summary>
        /// Duração do filme em minutos.
        /// </summary>
        public int Runtime { get; set; }

        /// <summary>
        /// Número total de avaliações que o filme recebeu.
        /// </summary>
        public int TotalRatings { get; set; }

        /// <summary>
        /// Soma de todas as notas dadas ao filme.
        /// </summary>
        public int SumOfRatings { get; set; }

        /// <summary>
        /// Nota média do filme, calculada automaticamente com base na soma das notas e no total de avaliações.
        /// </summary>
        public double Rating => TotalRatings > 0 ? (double)SumOfRatings / TotalRatings : 0;

        /// <summary>
        /// URL do trailer do filme.
        /// </summary>
        public string Trailer { get; set; }

        /// <summary>
        /// Identificador da nacionalidade do filme.
        /// </summary>
        public Guid NationalityId { get; set; }

        /// <summary>
        /// Identificador do estúdio que produziu o filme.
        /// </summary>
        public Guid StudioId { get; set; }

        /// <summary>
        /// Identificador do diretor responsável pelo filme.
        /// </summary>
        public Guid DirectorId { get; set; }

        /// <summary>
        /// Identificador do diretor responsável pelo filme.
        /// </summary>
        public Guid GenderId { get; set; }

        /// <summary>
        /// Lista de URLs das imagens associadas ao filme.
        /// </summary>
        public virtual ICollection<MovieImage> Images { get; set; }

        /// <summary>
        /// Coleção de prêmios recebidos pelo filme.
        /// </summary>
        public virtual ICollection<Award> Awards { get; set; }
    }
}
