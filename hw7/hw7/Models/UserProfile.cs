using System.ComponentModel.DataAnnotations;

namespace hw7.Models
{
    public class UserProfile
    {
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Укажите корректные данные")]
        [Display(Name="Имя")]
        public string FirstName { get; set; }
        
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Укажите корректные данные")]
        public string LastName { get; set; }
        
        [Range(1, 110, ErrorMessage = "Укажите корректные данные")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        
        [Display(Name = "Пол")]
        public Gender gender { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Age} {gender}";
        }
    }
    
    public enum Gender
    {
        Male,
        Female
    }
}