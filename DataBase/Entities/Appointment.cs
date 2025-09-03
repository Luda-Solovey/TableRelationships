using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; } // якби треба було, щоб це поле (структурне, а не ссилочне) було необов'язковим, тоді б було ось так public DateTime? Date { get; set; }
        //public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
        //public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public bool CallingHome { get; set; }
    }
}
