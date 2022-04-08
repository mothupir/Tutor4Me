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

        public int TutorId { get; set; }
        public int ModuleId { get; set; }
    }
}
