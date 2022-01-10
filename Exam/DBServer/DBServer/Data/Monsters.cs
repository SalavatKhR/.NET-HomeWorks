namespace DbServer.Data
{
    public class Monsters
    {
        public int Id { get; set; }
        
        public string MonsterName { get; set; }

        public int HitPoints { get; set; }
        
        public int AttackModifier { get; set; } 
        
        public int AttackPerRound { get; set; } 
        
        public string Damage { get; set; }
        
        public int DamageModifier { get; set; }

        public int AC { get; set; }
        
        public int MinACtoAlwaysHit { get; set; }
    }
}