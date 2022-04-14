using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public class StudentService : IStudentService
    {
        private DataContext _context;
        public StudentService(DataContext context)
        {
            _context = context;
        }


        public List<Tutor> getAllTutorsByModule(int moduleId)
        {
            List<Tutor> tutors = new List<Tutor>();
            List<TutoredModule> tutoredModules = _context.TutoredModules.Where(tm => tm.ModuleId == moduleId).ToList();
            foreach (TutoredModule tm in tutoredModules)
            {
                tutors.Add(this.getTutorInformation(tm.TutorId));
            }
            return tutors;
        }
        public List<Tutor> getAllTutors()
        {
            return _context.Tutors.ToList();
        }
        public List<Module> getOfferedModulesByTutor(int tutorId)
        {
            List<Module> modules = new List<Module>();
            List<TutoredModule> tutoredModules = _context.TutoredModules.Where(tm => tm.TutorId == tutorId).ToList();
            foreach (TutoredModule tm in tutoredModules)
            {
                Module module = _context.Modules.Find(tm.ModuleId);
                modules.Add(module);
            }
            return modules;
        }
        public Tutor? getTutorInformation(int tutorId)
        {
            return _context.Tutors.Find(tutorId);
        }
    }
}
