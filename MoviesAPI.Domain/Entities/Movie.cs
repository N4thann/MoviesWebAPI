namespace MoviesAPI.Domain.Entities
{
    /// <summary>
    /// Represents a movie with details such as title, synopsis, release year, runtime, ratings, and associated awards.
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Gets or sets the unique identifier of the movie.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the movie.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the synopsis of the movie.
        /// </summary>
        public string Synopsis { get; set; }

        /// <summary>
        /// Gets or sets the release year of the movie.
        /// </summary>
        public int ReleaseYear { get; set; }

        /// <summary>
        /// Gets or sets the runtime of the movie in minutes.
        /// </summary>
        public int Runtime { get; set; }

        /// <summary>
        /// Gets or sets the total number of ratings the movie has received.
        /// </summary>
        public int TotalRatings { get; set; }

        /// <summary>
        /// Gets or sets the sum of all ratings given to the movie.
        /// </summary>
        public int SumOfRatings { get; set; }

        /// <summary>
        /// Gets the average rating of the movie, calculated automatically based on the sum of ratings and the total number of ratings.
        /// </summary>
        public double Rating => TotalRatings > 0 ? (double)SumOfRatings / TotalRatings : 0;

        /// <summary>
        /// Gets or sets the URL of the movie trailer.
        /// </summary>
        public string Trailer { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the movie's nationality.
        /// </summary>
        public int NationalityId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the studio that produced the movie.
        /// </summary>
        public int StudioId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the director of the movie.
        /// </summary>
        public int DirectorId { get; set; }

        /// <summary>
        /// Gets or sets the list of image URLs associated with the movie.
        /// </summary>
        public List<string> Images { get; set; }

        /// <summary>
        /// Gets or sets the collection of awards received by the movie.
        /// </summary>
        public virtual ICollection<Award> Awards { get; set; }
    }
}
