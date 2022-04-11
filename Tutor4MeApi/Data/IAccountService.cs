using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public interface IAccountService
    {
        // Tutor
        int CreateTutor(Tutor tutor);


        // Student
        int CreateStudent(Student student);
    }
}
