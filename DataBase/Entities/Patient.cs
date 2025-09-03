using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Patient : Person
    {
        public string? Diagnosis { get; set; }

        //public Doctor? FamilyDoctor { get; set; }
        public Department Department { get; set; } = new Department();
        public List<Doctor> Doctors { get; set; } = []; //теж саме, що й   new List<Doctor>();

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
