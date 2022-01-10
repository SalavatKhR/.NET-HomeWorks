using Microsoft.EntityFrameworkCore;

namespace DbServer.Data
{
    public class MonstersContext: DbContext
    {
        public DbSet<Monsters> MonstersData { get; set; }
        public MonstersContext(DbContextOptions<MonstersContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monsters>().HasData(
                new Monsters()
                {
                    Id = 1,
                    MonsterName = "Griffon",
                    HitPoints = 59,
                    AtackModifier = 0,
                    AtackPerRound = 0,
                    Damage = 0,
                    Weapon = 0,
                    AC = 0,
                    MinACtoAlwaysHit = 0,
                    DamagePerRound  = 0,
                },
                new Monsters()
                {
                    Id = 2,
                    MonsterName = "Swarm of rats",
                    HitPoints = 24,
                    AtackModifier = 0,
                    AtackPerRound = 0,
                    Damage = 0,
                    Weapon = 0,
                    AC = 0,
                    MinACtoAlwaysHit = 0,
                    DamagePerRound  = 0,
                },
                new Monsters()
                {
                    Id = 3,
                    MonsterName = "Mage",
                    HitPoints = 40,
                    AtackModifier = 0,
                    AtackPerRound = 0,
                    Damage = 0,
                    Weapon = 0,
                    AC = 0,
                    MinACtoAlwaysHit = 0,
                    DamagePerRound  = 0,
                },
                new Monsters()
                {
                    Id = 4,
                    MonsterName = "Fire giant dreadnought",
                    HitPoints = 187,
                    AtackModifier = 5,
                    AtackPerRound = 0,
                    Damage = 0,
                    Weapon = 0,
                    AC = 21,
                    MinACtoAlwaysHit = 0,
                    DamagePerRound  = 0,
                });
        }
    }
}