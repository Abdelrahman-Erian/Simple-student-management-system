using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Simple_student_management_system.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Hours { get; set; }
        public virtual ICollection<Student> Students{ get; set; }
    }
}
