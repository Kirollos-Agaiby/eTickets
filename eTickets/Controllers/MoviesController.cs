using eTickets.Data;
using eTickets.Models;
using eTickets.Services;
using eTickets.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        IMovieService movieService;
        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        //GetAll
        [HttpGet]
        public IActionResult Index()
        {
            List<Movie> movies = movieService.GetAllWithCinemasName();
            return View(movies);
        }

        //GetById
        [HttpGet]
        public IActionResult Details(int id)
        {
            Movie movie = movieService.GetById(id);
            return View(movie);
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            MovieandCinemaProducerMovieCategoryListsViewModel
                ListsViewModel = movieService.GetListsViewModel(new Movie());
            
            return View(ListsViewModel);
        }

        [HttpPost]
        public IActionResult SaveNew([Bind(include: "Name,Description,Price,ImageURL,MovieCategory,CinemaId,ProducerId")]Movie movie)
        {
            if (movie.Name != null)
            {
                movieService.Insert(movie);
                return RedirectToAction("Index");
            }
            MovieandCinemaProducerMovieCategoryListsViewModel
                ListsViewModel = movieService.GetListsViewModel(movie);

            return View("Create", ListsViewModel);
        }

        //Update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie movie = movieService.GetById(id);

            MovieandCinemaProducerMovieCategoryListsViewModel
                ListsViewModel = movieService.GetListsViewModel(movie);

            return View(ListsViewModel);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id, Movie movie)
        {
            if(movie != null && movie.Name != null)
            {
                movieService.Update(id, movie);
                return RedirectToAction("Index");
            }

            MovieandCinemaProducerMovieCategoryListsViewModel
                ListsViewModel = movieService.GetListsViewModel(movie);

            return View("Edit", ListsViewModel);
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            movieService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
