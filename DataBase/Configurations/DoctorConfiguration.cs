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
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasMany(d =>d.Appointments).WithOne(a => a.Doctor).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(d => d.Patients).WithMany(p => p.Doctors); 
            builder.HasOne(d => d.Department).WithMany(d => d.Doctors).OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
