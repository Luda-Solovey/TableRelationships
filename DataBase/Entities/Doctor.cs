
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    public class Doctor : Person
    {
        public string Speciality {  get; set; } = string.Empty;

        public double? Salary { get; set; }
        public Department? Department { get; set; }
        public List<Patient> Patients { get; set; } = [];

        //public List<Patient> PatientsAsFamily { get; set; } = [];

        public List<Appointment> Appointments { get; set; } = [];

    }
}
