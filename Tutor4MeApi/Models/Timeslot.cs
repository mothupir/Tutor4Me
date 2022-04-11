using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutor4MeApi.Models
{
    public class Timeslot
    {
        public Timeslot()
        {
        }

        public Timeslot(int timeslotId, int tutorId, int studentId, int moduleId, DateTime date, DateTime startTime, DateTime endTime)
        {
            TimeslotId = timeslotId;
            TutorId = tutorId;
            StudentId = studentId;
            ModuleId = moduleId;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeslotId { get; set; }
        [NotMapped]
        public Tutor Tutor { get; set; }
        public int TutorId { get; set; }
        [NotMapped]
        public Student Student { get; set; }
        public int StudentId { get; set; }
        [NotMapped]
        public Module Module { get; set; }
        public int ModuleId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
    }
}
