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

        // some not 
        public List<Cinema> GetAllCinemas()
        {
            List<Cinema> cinemas = Context.Cinemas.ToList();
            return cinemas;
        }
        public List<Producer> GetAllProducers()
        {
            List<Producer> producers = Context.Producers.ToList();
            return producers;
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
            oldMovie.Name           = oldMovie.Name;
            oldMovie.Description    = oldMovie.Description;
            oldMovie.Price          = oldMovie.Price;
            oldMovie.ImageURL       = oldMovie.ImageURL;
            oldMovie.StartDate      = oldMovie.StartDate;
            oldMovie.EndDate        = oldMovie.EndDate;
            oldMovie.MovieCategory  = oldMovie.MovieCategory;
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
