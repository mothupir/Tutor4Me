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

        // Check if a tutor with the same email exists, if so return 0, else add tutor to database and return 1
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

        // Check if a student with the same email exists, if so return 0, else add student to database and return 1
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
    }
}
