using eTickets.Models;
using eTickets.ViewModel;

namespace eTickets.Services
{
    public class MovieService : IMovieService
    {
        IMovieRepository movieRepository;
        ICinemaRepository cinemaRepository;
        IProducerRepository producerRepository;
        IMovieCategoryRepository movieCategoryRepository;
        public MovieService(IMovieRepository movieRepository, ICinemaRepository cinemaRepository,
            IProducerRepository producerRepository, IMovieCategoryRepository movieCategoryRepository)
        {
            this.movieRepository = movieRepository;
            this.cinemaRepository = cinemaRepository;
            this.producerRepository = producerRepository;
            this.movieCategoryRepository = movieCategoryRepository;
        }


        public List<Movie> GetAll()
        {
            List<Movie> movies = movieRepository.GetAll();
            return movies;
        }
        public List<Movie> GetAllWithCinemasName()
        {
            List<Movie> movies = movieRepository.GetAllWithCinemasName();
            return movies;
        }
        public MovieandCinemaProducerMovieCategoryListsViewModel GetListsViewModel(Movie movie)
        {
            MovieandCinemaProducerMovieCategoryListsViewModel
                ListsViewModel = new MovieandCinemaProducerMovieCategoryListsViewModel();

            ListsViewModel.Name = movie.Name;
            ListsViewModel.Description = movie.Description;
            ListsViewModel.Price = movie.Price;
            ListsViewModel.ImageURL = movie.ImageURL;
            ListsViewModel.MovieCategory = movie.MovieCategory;
            ListsViewModel.CinemaId = movie.CinemaId;
            ListsViewModel.ProducerId = movie.ProducerId;
            ListsViewModel.cinemas = cinemaRepository.GetAll();
            ListsViewModel.producers = producerRepository.GetAll();
            ListsViewModel.movieCategorys = movieCategoryRepository.GetAllMovieCategory();

            return ListsViewModel;
        }
        public Movie GetById(int id)
        {
            Movie movie = movieRepository.GetById(id);
            return movie;
        }
        public void Insert(Movie newMovie)
        {
            movieRepository.Insert(newMovie);
        }
        public void Update(int id, Movie newMovie)
        {
            movieRepository.Update(id, newMovie);
        }
        public void Delete(int id)
        {
            movieRepository.Delete(id);
        }
    }
}
