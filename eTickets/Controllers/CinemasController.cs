using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        ICinemaRepository cinemaRepository;
        public CinemasController(ICinemaRepository cinemaRepository)
        {
            this.cinemaRepository = cinemaRepository;
        }

        //GetAll
        [HttpGet]
        public IActionResult Index()
        {
            List<Cinema> cinemas = cinemaRepository.GetAll();
            return View(cinemas);
        }

        //GetById
        [HttpGet]
        public IActionResult Details(int id)
        {
            Cinema cinema = cinemaRepository.GetById(id);
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
                cinemaRepository.Insert(cinema);
                return RedirectToAction("Index");
            }
            return View("Create", cinema);
        }


        //Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Cinema cinema = cinemaRepository.GetById(id);
            return View(cinema);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id, Cinema cinema)
        {
            if(cinema != null && cinema.Name != null)
            {
                cinemaRepository.Update(id, cinema);
                return RedirectToAction("Index");
            }
            return View("Edit", cinema);
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            cinemaRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
