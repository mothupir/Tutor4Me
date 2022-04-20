using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public interface IStudentService
    {
        //get all tutors by module
        //get all tutors 
        //get modules offered by tutor
        //get tutor information

        List<Tutor> getAllTutorsByModule(int moduleId);
        List<Tutor> getAllTutors();
        List<Module> getOfferedModulesByTutor(int tutorId);
        Tutor? getTutorInformation(int tutorId);

    }
}
