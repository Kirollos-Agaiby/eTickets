using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        IProducerService service;
        public ProducersController(IProducerService service)
        {
            this.service = service;
        }

        // GetAll
        [HttpGet]
        public IActionResult Index()
        {
            List<Producer> producers = service.GetAll();
            return View(producers);
        }

        //GetById
        [HttpGet]
        public IActionResult Details(int id)
        {
            Producer producer = service.GetById(id);
            if (producer == null)
            {
                return View("NotFound");
            }
            return View(producer);
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Producer());
        }

        [HttpPost]
        public IActionResult SaveNew([Bind(include: "ProfilePictureURL,FullName,Bio")] Producer producer) 
        {
            if(producer.FullName != null)
            {
                service.Insert(producer);
                return RedirectToAction("Index");
            }
            return View("Create", producer);
        }


        // Update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Producer producer = service.GetById(id);
            return View(producer);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id, Producer producer)
        {
            if(producer != null && producer.FullName != null)
            {
                service.Update(id, producer);
                return RedirectToAction("Index");
            }
            return View("Edit", producer);
        }

        // Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
