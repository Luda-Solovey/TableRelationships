
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasMany(d => d.Doctors).WithOne(d => d.Department).OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.Corpus).IsRequired();
            builder.Property(d => d.Name).IsRequired();
        }
    }
}
