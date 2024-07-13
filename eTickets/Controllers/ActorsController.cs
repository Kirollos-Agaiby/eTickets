using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        IActorService service;
        public ActorsController(IActorService service)
        {
            this.service = service;
        }


        // GetAll
        [HttpGet]
        public IActionResult Index()
        {
            List<Actor> actors = service.GetAll();
            return View(actors);
        }

        // GetById
        public IActionResult Details(int id)
        {
            Actor actor = service.GetById(id);
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
                service.Insert(actor);
                return RedirectToAction("Index");
            }
            return View("Create", actor);
        }


        // Update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Actor actor = service.GetById(id);
            return View(actor);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id, Actor actor)
        {
            if(actor != null && actor.FullName != null)
            {
                service.Update(id, actor);
                return RedirectToAction("Index");
            }
            return View("Edit", actor);
        }

        // Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }


        // You can Use Confirm Delete too.

    }
}
