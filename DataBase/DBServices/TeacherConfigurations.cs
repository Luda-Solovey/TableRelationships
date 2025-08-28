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
    internal class TeacherConfigurations : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasMany(t => t.Pupils).WithMany(p => p.Teachers);//це не обов'язково прописувати, якщо використовуємо підхід код конвеншн
                                                                    //але якщо використовуємо підхід FluentAPI , то все прописуємо
        }
    }
}
