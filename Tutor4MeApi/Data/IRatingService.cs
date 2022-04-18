using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public interface IRatingService
    {
        int AddRating(int tutorId, int rating);
        int GetTutorAverageRating(int tutorId);
        int GetTutorAverageRatingByModule(int tutorId, int moduleId);
    }
}