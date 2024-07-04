using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        IActorService service;
        public ActorsController(IActorService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            List<Actor> actors = service.GetAll();
            return View(actors);
        }
    }
}
