using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        ICinemaService service;
        public CinemasController(ICinemaService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            List<Cinema> cinemas = service.GetAll();
            return View(cinemas);
        }
    }
}
