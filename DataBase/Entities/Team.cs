
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    [PrimaryKey(nameof(Id))]
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public List<Player>? Players { get; set; }

    }
}
