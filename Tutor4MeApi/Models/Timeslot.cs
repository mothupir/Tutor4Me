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

        public Timeslot(Timeslot timeslot)
        {
            TimeslotId = timeslot.TimeslotId;
            TutorId= timeslot.TutorId;
            StudentId = timeslot.StudentId;
            ModuleId = timeslot.ModuleId;
            Date = timeslot.Date;
            StartTime = timeslot.StartTime;
            EndTime = timeslot.EndTime;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeslotId { get; set; }
        public int TutorId { get; set; }
        public int StudentId { get; set; }
        public int ModuleId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
    }
}
