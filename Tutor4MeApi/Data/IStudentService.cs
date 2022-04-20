using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public interface IStudentService
    {
        //get all tutors by module
        //get all tutors 
        //get modules offered by tutor
        //get tutor information

        int CreateStudent(Student student);
        Student? GetStudent(int id);
        int UpdateStudent(Student student);
        int DeleteStudent(int id);

    }
}
