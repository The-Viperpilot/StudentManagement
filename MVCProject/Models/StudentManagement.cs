using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class StudentManagement
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set;}
        public int StudentAge { get; set;}
        public string StudentGender { get; set;}
        public string StudentGrade { get; set; }
        public string StudentEmail { get; set;}
        public int StudentPhoneNumber { get; set;}
        
    }
}
