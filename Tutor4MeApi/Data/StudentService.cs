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
