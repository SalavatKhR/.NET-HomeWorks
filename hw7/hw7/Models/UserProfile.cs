using System.ComponentModel.DataAnnotations;

namespace hw7.Models
{
    public record UserProfile(
        [Required]string FirstName, [Required]string LastName, UserProfile.Gender? gender, int? age)
    {
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }

        public enum Gender
        {
            Male,
            Female
        }
        
    }
}