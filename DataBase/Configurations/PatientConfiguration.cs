using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            builder.HasMany(p => p.Doctors).WithMany(d => d.Patients);
            builder.HasMany(p => p.Appointments).WithOne(a => a.Patient).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Department).WithMany(d => d.Patients);
            //builder.HasOne(p => p.FamilyDoctor).WithMany(d => d.PatientsAsFamily);
        }
    }
}
