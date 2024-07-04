using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        IProducerService service;
        public ProducersController(IProducerService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            List<Producer> producers = service.GetAll();
            return View(producers);
        }
    }
}
