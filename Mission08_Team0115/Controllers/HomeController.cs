using Microsoft.AspNetCore.Mvc;
using Mission08_Team0115.Models;
using System.Diagnostics;

namespace Mission08_Team0115.Controllers
{
    public class HomeController : Controller
    {

        private IQuadrantRepository _repo;

        public HomeController(IQuadrantRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Task()
        {
            return View(new Quadrant());
        }

        [HttpPost]
        public IActionResult Task(Quadrant q)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(q);
            }
            return View(new Quadrant());
        }

        [HttpGet]
        public IActionResult Quadrants()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        
    }
}
