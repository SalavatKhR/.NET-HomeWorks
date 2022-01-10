namespace DbServer.Data
{
    public class Monsters
    {
        public int Id { get; set; }
        
        public string MonsterName { get; set; }

        public int HitPoints { get; set; }
        
        public int AtackModifier { get; set; } 
        
        public int AtackPerRound { get; set; } 
        
        public int Damage { get; set; }
        
        public int Weapon { get; set; }
        
        public int AC { get; set; }
        
        public int MinACtoAlwaysHit { get; set; } 
        
        public int DamagePerRound { get; set; } 
    }
}