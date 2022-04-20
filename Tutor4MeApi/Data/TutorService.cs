using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public class TutorService : ITutorService
    {
        private DataContext _context;

        public TutorService(DataContext context)
        {
            _context = context;
        }

        public int AddTutoredModule(int tutorId, int moduleId)
        {
            var tutoredModule = _context.TutoredModules.Where(t => t.TutorId == tutorId && t.ModuleId == moduleId).FirstOrDefault();

            if(tutoredModule != null)
            {
                return 0;
            }

            tutoredModule = new TutoredModule()
            {
                TutorId = tutorId,
                ModuleId = moduleId
            };

            _context.TutoredModules.Add(tutoredModule);
            _context.SaveChanges();
            return 1;
        }

        public int RemoveTutoredModule(int tutorId, int moduleId)
        {
            var tutoredModule = _context.TutoredModules.Where(t => t.TutorId == tutorId && t.ModuleId == moduleId).FirstOrDefault();

            if (tutoredModule == null)
            {
                return 0;
            }

            _context.TutoredModules.Remove(tutoredModule);
            _context.SaveChanges();
            return 1;
        }

        public int CreateTutor(Tutor tutor)
        {
            var checkTutor = _context.Tutors.Where(t => t.EmailAddress.ToLower() == tutor.EmailAddress.ToLower()).FirstOrDefault();

            if (checkTutor != null)
            {
                return 0;
            }

            _context.Tutors.Add(tutor);
            _context.SaveChanges();
            return 1;
        }

        public Dictionary<string, string> GetTutor(int id)
        {
            var map = new Dictionary<string, string>();
            var tutor = _context.Tutors.Find(id);

            if (tutor == null)
            {
                return map;
            }

            var rating = GetTutorAverageRating(tutor.TutordId);


            map.Add("Name", tutor.FirstName + " " + tutor.LastName);
            map.Add("Email", tutor.EmailAddress);
            map.Add("Number", tutor.PhoneNumber);
            map.Add("Rating", rating.ToString());

            return map;

        }

        public int UpdateTutor(Tutor tutor)
        {
            var checkTutor = _context.Tutors.Find(tutor.TutordId);

            if (checkTutor == null)
            {
                return 0;
            }

            checkTutor = new Tutor(tutor);

            _context.Tutors.Update(checkTutor);
            _context.SaveChanges();
            return 1;
        }

        public int DeleteTutor(int id)
        {
            var tutor = _context.Tutors.Find(id);

            if (tutor == null)
            {
                return 0;
            }

            _context.Tutors.Remove(tutor);
            _context.SaveChanges();
            return 1;
        }

        public int AddRating(int tutorId, int rating)
        {

            var checkTutor = _context.Tutors.Find(tutorId);

            if (checkTutor == null)
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

        public int GetTutorAverageRating(int tutorId)
        {

            var checkTutor = _context.Tutors.Find(tutorId);

            if (checkTutor == null)
            {
                return 0;
            }

            List<Rating> tutorRatings = _context.Ratings.Where(r => r.TutorId == tutorId).ToList();

            var totalScore = 0;
            foreach (Rating r in tutorRatings)
            {
                totalScore = totalScore + r.Score;
            }

            var averageRating = totalScore / tutorRatings.Count;

            return averageRating;

        }


        public List<Tutor> getAllTutorsByModule(int moduleId)
        {
            List<Tutor> tutors = new List<Tutor>();
            List<TutoredModule> tutoredModules = _context.TutoredModules.Where(tm => tm.ModuleId == moduleId).ToList();
            foreach (TutoredModule tm in tutoredModules)
            {
                tutors.Add(this.getTutorInformation(tm.TutorId));
            }
            return tutors;
        }
        public List<Tutor> getAllTutors()
        {
            return _context.Tutors.ToList();
        }

        public Tutor? getTutorInformation(int tutorId)
        {
            return _context.Tutors.Find(tutorId);
        }
    }
}
