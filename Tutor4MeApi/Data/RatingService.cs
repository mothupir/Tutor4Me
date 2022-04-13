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

        public int AddRating(Timeslot timeslot){

            var checkTimeslot = _context.Timeslots.Find(timeslot.TimeslotId);

            if(checkTimeslot == null)
            {
                return 0;
            }

            checkTimeslot = new Timeslot(timeslot);

            _context.Timeslots.Update(checkTimeslot);
            _context.SaveChanges();
            return 1;

        }

        public int GetTutorAverageRating(int tutorId){
            //TODO
            return 0;
        }

        public int GetTutorAverageRatingByModule(int tutorId, int moduleId){
            //TODO
            return 0;
        }
    
    }
}
