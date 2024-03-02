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

        //The get and post for submitting the task

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
            return RedirectToAction("Quadrants");
        }

        // Get for the quadrants

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

        //Get and post for editing tasks

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Quadrant recordToEdit = _repo.Quadrants
                .Single(x => x.Key == id);

            ViewBag.Categories = _repo.TaskCategories
                .OrderBy(x => x.Category)
                .ToList();

            return View("Task", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Quadrant updatedInfo)
        {
            ViewBag.Categories = _repo.TaskCategories
                .OrderBy(x => x.Category)
                .ToList();

            if (ModelState.IsValid)
            {
                _repo.UpdateTask(updatedInfo);
            }

            return RedirectToAction("Quadrants");
        }

        //Get and post for deleting tasks

        [HttpGet]
        public IActionResult Delete(int id)
        {
           Quadrant recordToDelete = _repo.Quadrants
                .Single(x => x.Key == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Quadrant application)
        {
            if (ModelState.IsValid)
            {
                _repo.RemoveTask(application);
            }

            return RedirectToAction("Quadrants");
        }
    }
}
