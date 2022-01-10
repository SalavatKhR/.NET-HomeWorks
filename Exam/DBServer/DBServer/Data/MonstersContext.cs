using Microsoft.EntityFrameworkCore;

namespace DbServer.Data
{
    public class MonstersContext: DbContext
    {
        public DbSet<Monsters> MonstersData { get; set; }
        public MonstersContext(DbContextOptions<MonstersContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monsters>().HasData(
                new Monsters()
                {
                    Id = 1,
                    MonsterName = "Knight",
                    HitPoints = 52,
                    AttackModifier = 5,
                    AttackPerRound = 2,
                    Damage = "2d6",
                    DamageModifier = 3,
                    AC = 18,
                    MinACtoAlwaysHit = 6,
                },
                new Monsters()
                {
                    Id = 2,
                    MonsterName = "Swarm of rats",
                    HitPoints = 24,
                    AttackModifier = 2,
                    AttackPerRound = 1,
                    Damage = "2d6",
                    AC = 10,
                    MinACtoAlwaysHit = 3
                },
                new Monsters()
                {
                    Id = 3,
                    MonsterName = "Baboon",
                    HitPoints = 3,
                    AttackModifier = 1,
                    AttackPerRound = 1,
                    Damage = "1d4",
                    DamageModifier = 0,
                    AC = 12,
                    MinACtoAlwaysHit = 2
                });
        }
    }
}