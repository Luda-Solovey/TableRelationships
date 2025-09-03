using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int Corpus {  get; set; }
        public string? Description { get; set; }

        public List<Doctor> Doctors { get; set; } = new List<Doctor>();

        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
