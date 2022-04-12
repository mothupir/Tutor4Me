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
    
    }
}
