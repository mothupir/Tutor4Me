using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public class TutorService : ITutorService
    {
        private DataContext _context;

        public TutorService(DataContext context)
        {
            _context = context;
        }

        public int AddTutoredModule(int tutorId, int moduleId)
        {
            var tutoredModule = _context.TutoredModules.Where(t => t.TutorId == tutorId && t.ModuleId == moduleId).FirstOrDefault();

            if(tutoredModule != null)
            {
                return 0;
            }

            tutoredModule = new TutoredModule()
            {
                TutorId = tutorId,
                ModuleId = moduleId
            };

            _context.TutoredModules.Add(tutoredModule);
            _context.SaveChanges();
            return 1;
        }

        public int RemoveTutoredModule(int tutorId, int moduleId)
        {
            var tutoredModule = _context.TutoredModules.Where(t => t.TutorId == tutorId && t.ModuleId == moduleId).FirstOrDefault();

            if (tutoredModule == null)
            {
                return 0;
            }

            _context.TutoredModules.Remove(tutoredModule);
            _context.SaveChanges();
            return 1;
        }
    }
}
