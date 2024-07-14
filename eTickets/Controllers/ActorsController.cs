using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        IActorRepository actorRepository;
        public ActorsController(IActorRepository actorRepository)
        {
            this.actorRepository = actorRepository;
        }


        // GetAll
        [HttpGet]
        public IActionResult Index()
        {
            List<Actor> actors = actorRepository.GetAll();
            return View(actors);
        }

        // GetById
        public IActionResult Details(int id)
        {
            Actor actor = actorRepository.GetById(id);
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
                actorRepository.Insert(actor);
                return RedirectToAction("Index");
            }
            return View("Create", actor);
        }


        // Update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Actor actor = actorRepository.GetById(id);
            return View(actor);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id, Actor actor)
        {
            if(actor != null && actor.FullName != null)
            {
                actorRepository.Update(id, actor);
                return RedirectToAction("Index");
            }
            return View("Edit", actor);
        }

        // Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            actorRepository.Delete(id);
            return RedirectToAction("Index");
        }


        // You can Use Confirm Delete too.

    }
}
