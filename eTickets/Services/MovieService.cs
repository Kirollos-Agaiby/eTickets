using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Services
{
    public class MovieService : IMovieService
    {
        AppDbContext Context; // = new AppDbContext();
        public MovieService(AppDbContext Context)
        {
            this.Context = Context;
        }
        public List<Movie> GetAll()
        {
            List<Movie> movies = Context.Movies.ToList();
            return movies;
        }
        public List<Movie> GetAllWithCinemasName()
        {
            List<Movie> movies = Context.Movies.Include(n => n.Cinema).ToList();
            return movies;
        }
        public Movie GetById(int id)
        {
            Movie movie = Context.Movies.FirstOrDefault(x => x.Id == id);
            return movie;
        }
        public void Insert(Movie newMovie)
        {
            Context.Movies.Add(newMovie);
            Context.SaveChanges();
        }
        public void Update(int id, Movie newMovie)
        {
            Movie oldMovie = GetById(id);
            oldMovie.Name           = newMovie.Name;
            oldMovie.Description    = newMovie.Description;
            oldMovie.Price          = newMovie.Price;
            oldMovie.ImageURL       = newMovie.ImageURL;
            oldMovie.StartDate      = newMovie.StartDate;
            oldMovie.EndDate        = newMovie.EndDate;
            oldMovie.MovieCategory  = newMovie.MovieCategory;
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            Movie movie = GetById(id);
            Context.Movies.Remove(movie);
            Context.SaveChanges();
        }
    }
}
