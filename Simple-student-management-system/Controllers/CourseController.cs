using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simple_student_management_system.Models;

namespace Simple_student_management_system.Controllers
{
    public class CourseController : Controller
    {
        AppDbContext Context = new AppDbContext();
        public IActionResult Index()
        {
            List<Course> Courses = Context.Courses.ToList();
            return View(Courses);
        }

        public IActionResult Details(string code)
        {
            Course course = Context.Courses.FirstOrDefault(c => c.Code == code);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        public IActionResult NewCourse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveNewCourse(Course crs)
        {
            Context.Courses.Add(crs);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
