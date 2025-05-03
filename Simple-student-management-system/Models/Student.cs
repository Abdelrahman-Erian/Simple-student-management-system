namespace Simple_student_management_system.Models
{
    public class Student
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public string Name { get; set; }      
        public string Email { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
