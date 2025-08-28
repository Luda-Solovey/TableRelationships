
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public Address? Address { get; set; } //навігаційна властивість. зв'язок один до  одного (одна персона - одна адреса)
    }
}
