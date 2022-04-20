using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public interface IAccountService
    {
        // Tutor
        int CreateTutor(Tutor tutor);
        Dictionary<string,string> GetTutor(int id);
        int UpdateTutor(Tutor tutor);
        int DeleteTutor(int id);


        // Student
        int CreateStudent(Student student);
        Student? GetStudent(int id);
        int UpdateStudent(Student student);
        int DeleteStudent(int id);
    }
}
