using System.ComponentModel.DataAnnotations;

namespace NewStudent.Models
{
    public class StudentGrade
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public User Student { get; set; }
        public List<CourseGrade> CourseGrades { get; set; }
    }

    public class CourseGrade
    {
        [Key]
        public string CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseName { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
        public string Grade { get; set; }
    }



}
