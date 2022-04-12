using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public interface IAccountService
    {
        int CreateTutor(Tutor tutor);
        int CreateStudent(Student student);
    }
}
