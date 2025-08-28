using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DBServices
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.PersonId);//це не обов'язково прописувати, якщо використовуємо підхід код конвеншн
                                            //але якщо використовуємо підхід FluentAPI , то все прописуємо

           //builder.HasOne(a => a.Person).WithOne(b => b.Address);// достатньо прописати налаштування зв'язку в батьківському класі-сутностей (в мене прописано в PersonConfigurations) 
        }
    }
}
