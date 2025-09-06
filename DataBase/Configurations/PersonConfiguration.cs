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
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //builder.UseTpcMappingStrategy().ToTable("People");// цей рядок тільки для підходу TPC (Table per Concrete Class)
            builder.ToTable("People");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasOne(p => p.Address)
                .WithOne(a => a.Person)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(p => new {p.FirstName, p.LastName}).IsUnique(false);
            builder.HasIndex(p => p.Phone).IsUnique();

            builder.Property(p => p.FirstName).HasMaxLength(100);
            builder.Property(p => p.LastName).HasMaxLength(100);
            builder.Property(p => p.Phone).HasMaxLength(15);
        }
    }
}
