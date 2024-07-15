using eTickets.Models;
using eTickets.ViewModel;

namespace eTickets.Services
{
    public interface IMovieService
    {
        public List<Movie> GetAll();
        public List<Movie> GetAllWithCinemasName();
        public Movie GetById(int id);
        public void Insert(Movie newMovie);
        public void Update(int id, Movie newMovie);
        public void Delete(int id);
        public MovieandCinemaProducerMovieCategoryListsViewModel GetListsViewModel(Movie movie);

    }
}