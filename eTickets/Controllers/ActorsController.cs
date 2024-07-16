using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        IActorService actorService;
        public ActorsController(IActorService actorService)
        {
            this.actorService = actorService;
        }


        // GetAll
        [HttpGet]
        public IActionResult Index()
        {
            List<Actor> actors = actorService.GetAll();
            return View(actors);
        }

        // GetById
        public IActionResult Details(int id)
        {
            Actor actor = actorService.GetById(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }


        // Insert
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Actor());
        }


        [HttpPost]
        public IActionResult SaveNew([Bind(include:"ProfilePictureURL,FullName,Bio")]Actor actor)
        {
            if(actor.FullName != null)
            {
                actorService.Insert(actor);
                return RedirectToAction("Index");
            }
            return View("Create", actor);
        }


        // Update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Actor actor = actorService.GetById(id);
            return View(actor);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id, Actor actor)
        {
            if(actor != null && actor.FullName != null)
            {
                actorService.Update(id, actor);
                return RedirectToAction("Index");
            }
            return View("Edit", actor);
        }

        // Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            actorService.Delete(id);
            return RedirectToAction("Index");
        }


        // You can Use Confirm Delete too.

    }
}
