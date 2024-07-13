using eTickets.Models;

namespace eTickets.Services
{
    public interface IMovieService
    {
        List<Movie> GetAll();
        List<Movie> GetAllWithCinemasName();
        Movie GetById(int id);
        void Insert(Movie newMovie);
        void Update(int id, Movie newMovie);
        void Delete(int id);

        // asasdc
        List<Cinema> GetAllCinemas();
        List<Producer> GetAllProducers();
    }
}
