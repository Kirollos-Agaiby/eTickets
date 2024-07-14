using eTickets.Data;
using eTickets.Models;
using eTickets.Services;
using eTickets.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        IMovieRepository movieRepository;
        ICinemaRepository cinemaRepository;
        IProducerRepository producerRepository;
        IMovieCategoryRepository movieCategoryRepository;

        public MoviesController(IMovieRepository movieRepository, ICinemaRepository cinemaRepository,
            IProducerRepository producerRepository, IMovieCategoryRepository movieCategoryRepository)
        {
            this.movieRepository = movieRepository;
            this.cinemaRepository = cinemaRepository;
            this.producerRepository = producerRepository;
            this.movieCategoryRepository = movieCategoryRepository;
        }

        //GetAll
        [HttpGet]
        public IActionResult Index()
        {
            List<Movie> movies = movieRepository.GetAllWithCinemasName();
            return View(movies);
        }

        //GetById
        [HttpGet]
        public IActionResult Details(int id)
        {
            Movie movie = movieRepository.GetById(id);
            return View(movie);
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            MovieandCinemasandProducersandMovieCategoriesListsViewModel
                movieandCinemasandProducersandMovieCategoriesListsViewModel
                    = new MovieandCinemasandProducersandMovieCategoriesListsViewModel();

            movieandCinemasandProducersandMovieCategoriesListsViewModel.cinemas = cinemaRepository.GetAll();
            movieandCinemasandProducersandMovieCategoriesListsViewModel.producers = producerRepository.GetAll();
            movieandCinemasandProducersandMovieCategoriesListsViewModel.movieCategorys = movieCategoryRepository.GetAllMovieCategory();
            return View(movieandCinemasandProducersandMovieCategoriesListsViewModel);
        }

        [HttpPost]
        public IActionResult SaveNew([Bind(include: "Name,Description,Price,ImageURL,MovieCategory,CinemaId,ProducerId")]Movie movie)
        {
            if (movie.Name != null)
            {
                movieRepository.Insert(movie);
                return RedirectToAction("Index");
            }
            MovieandCinemasandProducersandMovieCategoriesListsViewModel 
                movieandCinemasandProducersandMovieCategoriesListsViewModel 
                    = new MovieandCinemasandProducersandMovieCategoriesListsViewModel();

            movieandCinemasandProducersandMovieCategoriesListsViewModel.Name = movie.Name;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.Description = movie.Description;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.Price = movie.Price;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.ImageURL = movie.ImageURL;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.MovieCategory = movie.MovieCategory;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.CinemaId = movie.CinemaId;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.ProducerId = movie.ProducerId;

            movieandCinemasandProducersandMovieCategoriesListsViewModel.cinemas = cinemaRepository.GetAll();
            movieandCinemasandProducersandMovieCategoriesListsViewModel.producers = producerRepository.GetAll();
            movieandCinemasandProducersandMovieCategoriesListsViewModel.movieCategorys = movieCategoryRepository.GetAllMovieCategory();

            return View("Create", movieandCinemasandProducersandMovieCategoriesListsViewModel);
        }

        //Update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie movie = movieRepository.GetById(id);

            MovieandCinemasandProducersandMovieCategoriesListsViewModel
                movieandCinemasandProducersandMovieCategoriesListsViewModel
                    = new MovieandCinemasandProducersandMovieCategoriesListsViewModel();

            movieandCinemasandProducersandMovieCategoriesListsViewModel.Id = movie.Id;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.Name = movie.Name;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.Description = movie.Description;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.Price = movie.Price;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.ImageURL = movie.ImageURL;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.StartDate = movie.StartDate;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.EndDate = movie.EndDate;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.MovieCategory = movie.MovieCategory;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.CinemaId = movie.CinemaId;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.ProducerId = movie.ProducerId;

            movieandCinemasandProducersandMovieCategoriesListsViewModel.cinemas = cinemaRepository.GetAll();
            movieandCinemasandProducersandMovieCategoriesListsViewModel.producers = producerRepository.GetAll();
            movieandCinemasandProducersandMovieCategoriesListsViewModel.movieCategorys = movieCategoryRepository.GetAllMovieCategory();
            return View(movieandCinemasandProducersandMovieCategoriesListsViewModel);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id, Movie movie)
        {
            if(movie != null && movie.Name != null)
            {
                movieRepository.Update(id, movie);
                return RedirectToAction("Index");
            }

            MovieandCinemasandProducersandMovieCategoriesListsViewModel
                movieandCinemasandProducersandMovieCategoriesListsViewModel
                    = new MovieandCinemasandProducersandMovieCategoriesListsViewModel();

            movieandCinemasandProducersandMovieCategoriesListsViewModel.Id = movie.Id;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.Name = movie.Name;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.Description = movie.Description;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.Price = movie.Price;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.ImageURL = movie.ImageURL;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.StartDate = movie.StartDate;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.EndDate = movie.EndDate;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.MovieCategory = movie.MovieCategory;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.CinemaId = movie.CinemaId;
            movieandCinemasandProducersandMovieCategoriesListsViewModel.ProducerId = movie.ProducerId;

            movieandCinemasandProducersandMovieCategoriesListsViewModel.cinemas = cinemaRepository.GetAll();
            movieandCinemasandProducersandMovieCategoriesListsViewModel.producers = producerRepository.GetAll();
            movieandCinemasandProducersandMovieCategoriesListsViewModel.movieCategorys = movieCategoryRepository.GetAllMovieCategory();

            return View("Edit", movieandCinemasandProducersandMovieCategoriesListsViewModel);
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            movieRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
