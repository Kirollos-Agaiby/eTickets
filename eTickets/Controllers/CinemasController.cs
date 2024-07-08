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

        //GetAll
        [HttpGet]
        public IActionResult Index()
        {
            List<Cinema> cinemas = service.GetAll();
            return View(cinemas);
        }

        //GetById
        [HttpGet]
        public IActionResult Details(int id)
        {
            Cinema cinema = service.GetById(id);
            if(cinema == null)
            {
                return View("NotFound");
            }
            return View(cinema);
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Cinema());
        }

        [HttpPost]
        public IActionResult SaveNew([Bind(include: "Logo,Name,Description")]Cinema cinema)
        {
            if(cinema.Name != null)
            {
                service.Insert(cinema);
                return RedirectToAction("Index");
            }
            return View("Create", cinema);
        }


        //Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Cinema cinema = service.GetById(id);
            return View(cinema);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id, Cinema cinema)
        {
            if(cinema != null && cinema.Name != null)
            {
                service.Update(id, cinema);
                return RedirectToAction("Index");
            }
            return View("Edit", cinema);
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
