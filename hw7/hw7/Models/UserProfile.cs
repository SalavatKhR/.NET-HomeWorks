using System.ComponentModel.DataAnnotations;

namespace hw7.Models
{
    public class UserProfile
    {
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Необходимо указать своё имя.")]
        [Display(Name="Имя")]
        public string FirstName { get; set; }
        
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Необходимо указать свою фамилию.")]
        public string LastName { get; set; }
        
        [Range(0, 150, ErrorMessage = "Необходимо указать корректное значение.")]
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
        Female,
        Male
    }
}