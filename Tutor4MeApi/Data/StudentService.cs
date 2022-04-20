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

        public int CreateStudent(Student student)
        {
            var checkStudent = _context.Students.Where(s => s.EmailAddress.ToLower() == student.EmailAddress.ToLower()).FirstOrDefault();
            if (checkStudent != null)
            {
                return 0;
            }

            _context.Students.Add(student);
            _context.SaveChanges();
            return 1;
        }

        public Student? GetStudent(int id)
        {
            return _context.Students.Find(id);
        }

        public int UpdateStudent(Student student)
        {
            var checkStudent = _context.Students.Find(student.StudentId);

            if (checkStudent == null)
            {
                return 0;
            }

            checkStudent = new Student(student);

            _context.Students.Update(checkStudent);
            _context.SaveChanges();
            return 1;
        }

        public int DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return 0;
            }

            _context.Students.Remove(student);
            _context.SaveChanges();
            return 1;
        }
    }
}
