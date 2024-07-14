using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        IProducerService producerService;
        public ProducersController(IProducerService producerService)
        {
            this.producerService = producerService;
        }

        // GetAll
        [HttpGet]
        public IActionResult Index()
        {
            List<Producer> producers = producerService.GetAll();
            return View(producers);
        }

        //GetById
        [HttpGet]
        public IActionResult Details(int id)
        {
            Producer producer = producerService.GetById(id);
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
                producerService.Insert(producer);
                return RedirectToAction("Index");
            }
            return View("Create", producer);
        }


        // Update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Producer producer = producerService.GetById(id);
            return View(producer);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id, Producer producer)
        {
            if(producer != null && producer.FullName != null)
            {
                producerService.Update(id, producer);
                return RedirectToAction("Index");
            }
            return View("Edit", producer);
        }

        // Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            producerService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
