using MovieBack.Data;
using MovieBack.Model;

namespace MovieBack.Business
{
    public class MovieService
    {
        private readonly MovieRepository _movieRepository;

        public MovieService()
        {
            _movieRepository = new MovieRepository(); 
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

        public Movie CreateMovie(Movie movie)
        {
            return _movieRepository.CreateMovie(movie);
        }

        public Movie UpdateMovie(int id, Movie movie)
        {
            return _movieRepository.UpdateMovie(id, movie);
        }

        public bool DeleteMovie(int id)
        {
            return _movieRepository.DeleteMovie(id);
        }
    }
}
