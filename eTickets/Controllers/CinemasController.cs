using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        ICinemaService cinemaService;
        public CinemasController(ICinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
        }

        //GetAll
        [HttpGet]
        public IActionResult Index()
        {
            List<Cinema> cinemas = cinemaService.GetAll();
            return View(cinemas);
        }

        //GetById
        [HttpGet]
        public IActionResult Details(int id)
        {
            Cinema cinema = cinemaService.GetById(id);
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
                cinemaService.Insert(cinema);
                return RedirectToAction("Index");
            }
            return View("Create", cinema);
        }


        //Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Cinema cinema = cinemaService.GetById(id);
            return View(cinema);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id, Cinema cinema)
        {
            if(cinema != null && cinema.Name != null)
            {
                cinemaService.Update(id, cinema);
                return RedirectToAction("Index");
            }
            return View("Edit", cinema);
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            cinemaService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
