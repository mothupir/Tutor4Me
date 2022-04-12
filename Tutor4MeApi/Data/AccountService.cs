using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public class AccountService : IAccountService
    {
        private DataContext _context;

        public AccountService(DataContext context)
        {
            _context = context;
        }

        // Tutor
        public int CreateTutor(Tutor tutor)
        {
            var checkTutor = _context.Tutors.Where(t => t.EmailAddress.ToLower() == tutor.EmailAddress.ToLower()).FirstOrDefault();

            if(checkTutor != null)
            {
                return 0;
            }

            _context.Tutors.Add(tutor);
            _context.SaveChanges();
            return 1;
        }

        public Tutor? GetTutor(int id)
        {
            return _context.Tutors.Find(id);
        }

        public int UpdateTutor(Tutor tutor)
        {
            var checkTutor = _context.Tutors.Find(tutor.TutordId);

            if(checkTutor == null)
            {
                return 0;
            }

            checkTutor = new Tutor(tutor);

            _context.Tutors.Update(checkTutor);
            _context.SaveChanges();
            return 1;
        }

        public int DeleteTutor(int id)
        {
            var tutor = _context.Tutors.Find(id);

            if(tutor == null)
            {
                return 0;
            }

            _context.Tutors.Remove(tutor);
            _context.SaveChanges();
            return 1;
        }

        // Student
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
