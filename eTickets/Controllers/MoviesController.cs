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
