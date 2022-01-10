using System.ComponentModel.DataAnnotations;

namespace UiServer.Models
{
    public class Hero
    {
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Укажите имя от 2 до 15 символов")]
        public string HeroName { get; set; }

        [Range(1, 100, ErrorMessage = "Укажите число от 0 до 100")]
        public int HitPoints { get; set; }
        
        [Range(1, 10, ErrorMessage = "Укажите число от 0 до 10")]
        public int AttackModifier { get; set; } 
        
        [Range(1, 10, ErrorMessage = "Укажите число от 0 до 10")]
        public int AttackPerRound { get; set; } 
        
        [Range(1, 100, ErrorMessage = "Укажите число от 0 до 100")]
        public int Damage { get; set; }
        
        [Range(1, 10, ErrorMessage = "Укажите число от 0 до 10")]
        public int DamageModifier { get; set; }
        
        [Range(1, 10, ErrorMessage = "Укажите число от 0 до 10")]
        public int Weapon { get; set; }
        
        [Range(1, 100, ErrorMessage = "Укажите число от 0 до 100")]
        [Display(Name = "AC")]
        public int AC { get; set; }
    }
}