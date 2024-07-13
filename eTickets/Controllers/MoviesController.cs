using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        IMovieService service;
        public MoviesController(IMovieService service)
        {
            this.service = service;
        }

        //GetAll
        [HttpGet]
        public IActionResult Index()
        {
            List<Movie> movies = service.GetAllWithCinemasName();
            return View(movies);
        }

        //GetById
        [HttpGet]
        public IActionResult Details(int id)
        {
            Movie movie = service.GetById(id);
            return View(movie);
        }


        //Create
        [HttpGet]
        public IActionResult Create()
        {
            //ViewData["Cinemas"] = service.Cinemas.GetAll();

            // how to call GetAll of Cinemas and Producers
            // using service layer 
            ViewData["cinemas"] = service.GetAllCinemas();
            ViewData["producers"] = service.GetAllProducers();
            return View(new Movie());
        }

        [HttpPost]
        public IActionResult SaveNew([Bind(include: "Name,Description,Price,ImageURL,MovieCategory,CinemaId,ProducerId")]Movie movie)
        {
            if (movie.Name != null)
            {
                service.Insert(movie);
                return RedirectToAction("Index");
            }

            ViewData["cinemas"] = service.GetAllCinemas();
            ViewData["producers"] = service.GetAllProducers();
            return View("Create", movie);
        }




        //Update



        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
