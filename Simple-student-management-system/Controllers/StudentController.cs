using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simple_student_management_system.Models;

namespace Simple_student_management_system.Controllers
{
    public class StudentController : Controller
    {
        AppDbContext Context = new AppDbContext();
        public IActionResult Index()
        {
            List<Student> Students = Context.Students.Include(s => s.Courses)
                                                     .ToList();
            return View(Students);
        }

        public IActionResult NewStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveNewStudent(Student St)
        {
            Context.Students.Add(St);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details( int id )
        {         
            Student student = Context.Students.Include( s => s.Courses )
                .FirstOrDefault(s => s.StudentID == id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            Student student = Context.Students.FirstOrDefault(s => s.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id, Student EditStudent)
        {
            Student student = Context.Students.FirstOrDefault(s => s.ID == id);
            student.StudentID = EditStudent.StudentID;
            student.Name = EditStudent.Name;
            student.Email = EditStudent.Email;
            Context.SaveChanges();
            return RedirectToAction("Details", new { id = student.StudentID });
        }

        public IActionResult Delete(int id)
        {
            Student student = Context.Students.FirstOrDefault(s => s.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }
            Context.Students.Remove(student);
            Context.SaveChanges();
            return View(student);
        }

        public IActionResult RegisterCourses(int id)
        {
            ViewBag.StudentId = id;
            List<Course> courses = Context.Courses.ToList();
            return View(courses);
        }
        [HttpPost]
        public IActionResult SaveRegisterCourses(int id, int Courses1, int Courses2,
                                                         int Courses3, int Courses4)
        {
            Student student = Context.Students
                             .Include(s => s.Courses).ToList()
                             .FirstOrDefault(s => s.StudentID == id);
            List<Course> courses = Context.Courses.ToList();
                var course = courses.FirstOrDefault(c => c.ID == Courses1);
                if( course != null && !student.Courses.Contains(course) )
                {
                     student.Courses.Add(course);
                }
                course = courses.FirstOrDefault(c => c.ID == Courses2);
                if (course != null && !student.Courses.Contains(course))
                {
                     student.Courses.Add(course);
                }
                course = courses.FirstOrDefault(c => c.ID == Courses3);
                if (course != null && !student.Courses.Contains(course))
                {
                    student.Courses.Add(course);
                }
                course = courses.FirstOrDefault(c => c.ID == Courses4);
                if (course != null && !student.Courses.Contains(course))
                {
                    student.Courses.Add(course);
                }

            Context.SaveChanges(); 
            return RedirectToAction("Details" , new {id = id}); 
        }
    }
}
