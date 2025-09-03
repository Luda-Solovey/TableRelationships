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
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property( a => a.Id)
                    .HasDefaultValueSql("NEWID()") // SQL Server: генерирует Guid на стороне БД
                    .ValueGeneratedOnAdd();

            builder.HasOne(a => a.Doctor).WithMany(d => d.Appointments).IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.Patient).WithMany(p => p.Appointments).IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

        }
    }
}
