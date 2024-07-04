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
        public IActionResult Index()
        {
            List<Movie> movies = service.GetAllWithCinemasName();
            return View(movies);
        }
    }
}
