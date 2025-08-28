using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.DBServices
{
    public class PersonConfigurations : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.HasOne(p => p.Address).WithOne(a => a.PersonAlias).HasForeignKey<Address>(p => p.PersonId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);//обов'язково прописуємо все це, якщо нам треба задати спосіб видалення, відміний від Cascade (і для FluentAPI, і для DataAnnotation)
        }
    }
}
