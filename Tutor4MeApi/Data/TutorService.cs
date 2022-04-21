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

        public Tutor? CreateTutor(Tutor tutor)
        {
            var checkTutor = _context.Tutors.Where(t => t.EmailAddress.ToLower() == tutor.EmailAddress.ToLower()).FirstOrDefault();

            if (checkTutor != null)
            {
                return null;
            }

            _context.Tutors.Add(tutor);
            _context.SaveChanges();
            return _context.Tutors.Where(t => t.EmailAddress == tutor.EmailAddress).FirstOrDefault();
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

            map.Add("TutorId", tutor.TutordId.ToString());
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
            if(tutorRatings.Count==0){
                return 0;
            }
            var totalScore = 0;
            foreach (Rating r in tutorRatings)
            {
                totalScore = totalScore + r.Score;
            }

            var averageRating = totalScore / tutorRatings.Count;

            return averageRating;

        }

        public List<Tutor> GetAllTutorsByModule(int moduleId)
        {
            List<Tutor> tutors = new List<Tutor>();
            List<TutoredModule> tutoredModules = _context.TutoredModules.Where(tm => tm.ModuleId == moduleId).ToList();
            foreach (TutoredModule tm in tutoredModules)
            {
                tutors.Add(this.GetTutorInformation(tm.TutorId));
            }
            return tutors;
        }

        public List<Dictionary<string,string>> GetAllTutors(string sortby)
        {
            List<Tutor>tutors = _context.Tutors.ToList();
             if(sortby.ToLower()=="name"){
                 return SortTutorsByName(tutors);
             }
             else if(sortby.ToLower()=="ratings"){
                 return SortTutorsByRatings(tutors);
             }
             else{
                var tutorList = new List<Dictionary<string,string>>();
                   foreach(Tutor t in tutors){
                        var tutorInfo = GetTutor(t.TutordId);
                        tutorList.Add(tutorInfo);
                   }
                return tutorList;
            }
        }
        public List<Dictionary<string,string>> SortTutorsByName(List<Tutor>tutors){
            //Sort((x, y) => x.age.CompareTo(y.age));
            tutors.Sort((t1,t2) => (t1.FirstName+t1.LastName).CompareTo(t2.FirstName+t2.LastName));
            var tutorList = new List<Dictionary<string,string>>();
            foreach(Tutor t in tutors){
                var tutorInfo = GetTutor(t.TutordId);
                tutorList.Add(tutorInfo);
            }
            return tutorList;
        }
        public List<Dictionary<string,string>> SortTutorsByRatings(List<Tutor>tutors){
            tutors.Sort((t2,t1) => GetTutorAverageRating(t1.TutordId).CompareTo(GetTutorAverageRating(t2.TutordId)));
            var tutorList = new List<Dictionary<string,string>>();
            foreach(Tutor t in tutors){
                var tutorInfo = GetTutor(t.TutordId);
                tutorList.Add(tutorInfo);
            }
            return tutorList;
        }
        public Tutor? GetTutorInformation(int tutorId)
        {
            return _context.Tutors.Find(tutorId);
        }
    }
}
