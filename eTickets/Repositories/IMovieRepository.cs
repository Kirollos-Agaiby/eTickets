using eTickets.Models;

namespace eTickets.Services
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        List<Movie> GetAllWithCinemasName();
        Movie GetById(int id);
        void Insert(Movie newMovie);
        void Update(int id, Movie newMovie);
        void Delete(int id);
    }
}
