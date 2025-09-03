using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    
    public class Person
    {
        //[Key]
        public int Id { get; set; }

        //[MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        //[MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        //[MaxLength(50)]
        public string Phone {  get; set; } = string.Empty;
        public DateOnly DataOfBirth { get; set; }

        public Address? Address { get; set; }
    }
}
