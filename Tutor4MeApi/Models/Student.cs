using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutor4MeApi.Models
{
    public class Student
    {
        public Student()
        {
        }

        public Student(int studentId, string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
        }

        public Student(Student student)
        {
            StudentId = student.StudentId;
            FirstName = student.FirstName;
            LastName = student.LastName;
            EmailAddress = student.EmailAddress;
            PhoneNumber = student.PhoneNumber;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(150)]
        public string EmailAddress { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
    }
}
