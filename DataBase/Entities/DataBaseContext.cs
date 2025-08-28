using DataBase.DBServices;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Entities
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfigurations());
            modelBuilder.ApplyConfiguration(new AddressConfigurations());
            modelBuilder.ApplyConfiguration(new PlayerConfigurations());
            modelBuilder.ApplyConfiguration(new TeamConfigurations());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use your connection string here  
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TablesRelationships;Trusted_Connection=True;TrustServerCertificate=true");
        }

        // Our tables in DataBase will be generated from these DbSet properties with the same names
        public DbSet<Address> Addresses { get; set; } 
        public DbSet<Person> People { get; set; }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
    }
}
