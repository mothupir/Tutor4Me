using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutor4MeApi.Models
{
    public class Tutor
    {
        public Tutor()
        {
        }

        public Tutor(int tutordId, string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            TutordId = tutordId;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
        }

        public Tutor(Tutor tutor)
        {
            TutordId = tutor.TutordId;
            FirstName = tutor.FirstName;
            LastName = tutor.LastName;
            EmailAddress = tutor.EmailAddress;
            PhoneNumber = tutor.PhoneNumber;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TutordId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(150)]
        public string EmailAddress { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
    }
}
