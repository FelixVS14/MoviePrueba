using Microsoft.EntityFrameworkCore;
using MovieBack.Model;
using System.Collections.Generic;
using System.Linq;

namespace MovieBack.Data
{
    public class MovieRepository
    {
        private readonly AppDbContext _dbContext;

        public MovieRepository()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Data Source=../MovieBack.Data/movie.db")
                .Options;

            _dbContext = new AppDbContext(options);
        }


        public List<Movie> GetAllMovies()
        {
            return _dbContext.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _dbContext.Movies.FirstOrDefault(m => m.Id == id);
        }

        public Movie CreateMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            return movie;
        }

        public Movie UpdateMovie(int id, Movie updatedMovie)
        {
            var existingMovie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);
            if (existingMovie == null)
            {
                return null;
            }

            existingMovie.Title = updatedMovie.Title;
            existingMovie.Director = updatedMovie.Director;
            existingMovie.Gender = updatedMovie.Gender;
            existingMovie.Description = updatedMovie.Description;

            _dbContext.SaveChanges();

            return existingMovie;
        }

        public bool DeleteMovie(int id) 
        {
            var existingMovie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);
            if (existingMovie == null)
            {
                return false;
            }

            _dbContext.Movies.Remove(existingMovie);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
