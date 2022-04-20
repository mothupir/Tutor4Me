using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public class RatingService : IRatingService
    {
        private DataContext _context;

        public RatingService(DataContext context)
        {
            _context = context;
        }

        public int AddRating(int tutorId, int rating){

            var checkTutor = _context.Tutors.Find(tutorId);

            if(checkTutor == null)
            {
                return 0;
            }

            var newRating = new Rating()
            {
                RatingId = 0,
                TutorId = tutorId,
                Score = rating
            };

            _context.Ratings.Add(newRating);
            _context.SaveChanges();
            return 1;

        }

        public int GetTutorAverageRating(int tutorId){

            var checkTutor = _context.Tutors.Find(tutorId);

            if(checkTutor == null)
            {
                return 0;
            }

            List<Rating> tutorRatings = _context.Ratings.Where(r => r.TutorId == tutorId).ToList();

            var totalScore = 0;
            foreach (Rating r in tutorRatings)
            {
                totalScore = totalScore + r.Score;
            }

            var averageRating = totalScore/tutorRatings.Count;

            return averageRating;
            
        }
    
    }
}
