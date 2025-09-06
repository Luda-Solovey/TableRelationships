using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Address
    {
        [Key, ForeignKey(nameof(Person))]
        public Guid PersonId { get; set; }
        public string City { get; set; } = "Dnipro";
        public string Street { get; set; } = string.Empty;
        public int HouseNumber { get; set; }
        public string? Apartment { get; set; }
        public string? ApartmentNumber { get; set; }

        public Person Person { get; set; } = null!;//якщо адреса є, то обов'язково повинна бути й персона
    }
}
