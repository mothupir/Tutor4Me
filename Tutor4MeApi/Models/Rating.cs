using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutor4MeApi.Models
{
    public class Rating
    {
        public Rating()
        {
        }

        public Rating(int ratingId, int tutorId, int score)
        {
            RatingId = ratingId;
            TutorId = tutorId;
            Score = score;
        }

        public Rating(Rating rating)
        {
            RatingId = rating.RatingId;
            TutorId = rating.TutorId;
            Score= rating.Score;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }
        [Required]
        public int TutorId { get; set; }
        [Required]
        public int Score { get; set; }
    }
}
