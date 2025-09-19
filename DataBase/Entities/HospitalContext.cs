using DataBase.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Entities
{
    public class HospitalContext : DbContext
    {
        public HospitalContext() 
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use your connection string here  
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Hospital;Trusted_Connection=True;TrustServerCertificate=true");
        }

        // Our tables in DataBase will be generated from these DbSet properties with the same names

        public DbSet<Person> People { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
