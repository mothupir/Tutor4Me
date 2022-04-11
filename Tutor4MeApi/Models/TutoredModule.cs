using System.ComponentModel.DataAnnotations.Schema;

namespace Tutor4MeApi.Models
{
    public class TutoredModule
    {
        public TutoredModule()
        {
        }

        public TutoredModule(int tutorId, int moduleId)
        {
            TutorId = tutorId;
            ModuleId = moduleId;
        }

        [NotMapped]
        public Tutor Tutor { get; set; }
        public int TutorId { get; set; }
        [NotMapped]
        public Module Module { get; set; }
        public int ModuleId { get; set; }
    }
}
