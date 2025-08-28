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
        //[Key, ForeignKey(nameof(Person))]//тут в дужках вказуємо навігаційну властивість
        public int PersonId { get; private set; }// зовнішній ключ на таблицю Pearson 
                                                    //для того, щоб відпрацював сценарій SetNull ОБОВ'ЯЗКОВО треба це поле позначити як null-able
        public Person PersonAlias { get; set; } = null!; //для того, щоб відпрацював сценарій SetNull ОБОВ'ЯЗКОВО треба це поле позначити як null-able
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? ZipCode { get; set; }
        public string Country { get; set; } = string.Empty;
    }
}
