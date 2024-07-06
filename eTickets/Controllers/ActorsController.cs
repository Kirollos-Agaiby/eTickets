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
        // Get : Actors/Create
        public IActionResult Create(string ProfilePictureURL, string FullName, string Bio)
        {
            Actor actor = new Actor();
            actor.ProfilePictureURL = ProfilePictureURL;
            actor.FullName = FullName;
            actor.Bio = Bio;
            service.Insert(actor);
            return View();
        }
    }
}
