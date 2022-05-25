using System.Collections.Generic;
using System.Linq;

namespace TutorialProjects.topoligicalSort
{
    public class Movie
    {
        public int MovieId { get; set; }
        public float Rating { get; set; }

        public List<Movie> SimilarMoviesList;

        public Movie(int movieId, float rating)
        {
            this.MovieId = movieId;
            this.Rating = rating;
            SimilarMoviesList = new List<Movie>();
        }

        public int GetId()
        {
            return this.MovieId;
        }

        public float GetRating()
        {
            return this.Rating;
        }

        public void AddSimilarMovie(Movie movie)
        {
            this.SimilarMoviesList.Add(movie);
            movie.SimilarMoviesList.Add(movie);

        }

        public List<Movie> GetSimilarMovieList()
        {
            return this.SimilarMoviesList;
        }
    }

    public class MovieFilter
    {
        public List<Movie> GetTopRatedMovieList(Movie movie, int numTopRatedMovies)
        {
            List<Movie> moviesVisit = new List<Movie>();
            Dictionary<int, Movie> visitedMovie = new Dictionary<int, Movie>();
            Movie[] topRatedMovie = new Movie[numTopRatedMovies];

            moviesVisit.AddRange(movie.GetSimilarMovieList());
            Movie currentMovie;

            while (moviesVisit.Count > 0)
            {
                currentMovie = moviesVisit.First();
                moviesVisit.Remove(currentMovie);
                if (!visitedMovie.ContainsKey(currentMovie.MovieId))
                {
                    visitedMovie[currentMovie.MovieId] = currentMovie;
                    Movie topMovie;
                    Movie reference = currentMovie;
                    for (int i = 0; i < numTopRatedMovies; i++)
                    {
                        topMovie = topRatedMovie[i];
                        if (topMovie == null)
                        {
                            topRatedMovie[i] = reference;
                            break;
                        }
                        else if (topMovie.Rating < reference.Rating)
                        {
                            topRatedMovie[i] = reference;
                            reference = topMovie;
                        }

                    }
                }
                foreach (var item in currentMovie.SimilarMoviesList)
                {
                    if (!visitedMovie.ContainsKey(item.MovieId))
                    {
                        moviesVisit.Add(item);
                    }
                }
            }

            return topRatedMovie.ToList();
        }
    }
}
