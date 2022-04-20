using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public interface ITutorService
    {
        int AddTutoredModule(int tutorId, int moduleId);
        int RemoveTutoredModule(int tutorId, int moduleId);
        Tutor? CreateTutor(Tutor tutor);
        Dictionary<string, string> GetTutor(int id);
        int UpdateTutor(Tutor tutor);
        int DeleteTutor(int id);
        int AddRating(int tutorId, int rating);
        int GetTutorAverageRating(int tutorId);
        List<Tutor> getAllTutorsByModule(int moduleId);
        List<Tutor> getAllTutors();
        Tutor? getTutorInformation(int tutorId);
    }
}
