using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.DBServices
{
    public class TeamConfigurations : IEntityTypeConfiguration<Team> 
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasMany(p => p.Players).WithOne(p => p.Team).HasForeignKey(p => p.TeamId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
