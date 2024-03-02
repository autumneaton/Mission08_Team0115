using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Categories = _repo.TaskCategories
                .OrderBy(x => x.Category).ToList();

            return View("Task", new Quadrant());
        }

        [HttpPost]
        public IActionResult Task(Quadrant q)
        {
            ViewBag.Categories = _repo.TaskCategories
                .OrderBy(x => x.Category).ToList();

            if (ModelState.IsValid)
            {
                _repo.AddTask(q);
            }
            return View("Task", new Quadrant());
        }

        [HttpGet]
        public IActionResult Quadrants()
        {
            List<Models.Quadrant> QuadrantList = _repo.Quadrants;
            return View(QuadrantList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        
    }
}
