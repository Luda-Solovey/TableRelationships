using DataBase.Entities;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TableRelationships
{
    public class Program
    {
        static void Main(string[] args)
        {

            using var db = new HospitalContext();

            // 1) створюю адреси длікарів

            Address doctoraddress1 = new Address()
            {
                Street = "Veselaya",
                HouseNumber = 1
            };

            Address doctoraddress2 = new Address()
            {
                Street = "Bogmi",
                HouseNumber = 2
            };

            Department department1 = new Department()
            {
                Name = "HartIssues",
                Corpus = 1
            };

            Department department2 = new Department()
            {
                Name = "Neurology",
                Corpus = 2
            };
            // 2) створюю лікарів, додаю в них створені вище адреси 

            Doctor doctor1 = new Doctor()
            {
                FirstName = "Anatoliy",
                LastName = "Fedorenko",
                Speciality = "LOR",
                Address = doctoraddress1,
                Phone = "0981111111",
                Department = department1
            };

            Doctor doctor2 = new Doctor()
            {
                FirstName = "Sergiy",
                LastName = "Frolov",
                Speciality = "Anasteziolog",
                Address = doctoraddress2,
                Phone = "0981111122",
                Department = department2
            };

            //3) створюю адреси пацієнтів
            Address patientAddress1 = new Address()
            {
                //PatientId = 1,
                Street = "Zarichanskaya1",
                HouseNumber = 1
            };

            Address patientAddress2 = new Address()
            {
                Street = "Zarichanskaya2",
                HouseNumber = 2
            };

            // 4) створюю пацієнтів. додаю їм створені вище адреси
            Patient patient1 = new Patient()
            {
                FirstName = "Olga",
                LastName = "Ivanova",
                DataOfBirth = new DateOnly(1980, 5, 1),
                Address = patientAddress1,
                Phone = "0981111133"
            };

            Patient patient2 = new Patient()
            {
                FirstName = "Tamara",
                LastName = "Krilova",
                DataOfBirth = new DateOnly(1985, 10, 10),
                Address = patientAddress2,
                Phone = "0981111144"
            };

            Patient patient3 = new Patient()
            {
                FirstName = "Vasilisa",
                LastName = "Ukolova",
                DataOfBirth = new DateOnly(1990, 11, 20),
                Phone = "0981111155",
                Address = new Address 
                {
                    City = "Kyiv",
                    Street = "Hreschatyk",
                    HouseNumber = 10
                }
            };

            // 5) створюю прийоми

            Appointment appointment1 = new Appointment()
            {
                Patient = patient1,
                Doctor = doctor1,
                CallingHome = false,
                Date = new DateTime(2025, 9, 3, 08, 00, 0)

            };

            Appointment appointment2 = new Appointment()
            {
                Patient = patient2,
                Doctor = doctor2,
                CallingHome = false,
                Date = new DateTime(2025, 9, 3, 08, 10, 0)
            };

            Appointment appointment3 = new Appointment()
            {
                Patient = patient3,
                Doctor = doctor1,
                CallingHome = true,
                Date = new DateTime(2025, 9, 3, 09, 00, 0)
            };
            doctor1.Appointments.AddRange([appointment1, appointment3]);
            doctor2.Appointments.Add(appointment2);

            doctor1.Patients.AddRange([ patient1, patient2 ]);// зв'язана сутність (PatientAddress) додасться автоматично
            doctor2.Patients.Add(patient3 );                // так як вона була вказана при створенні головної сутності (екземплярів Patient)

            db.Doctors.AddRange(doctor1, doctor2);
            db.Patients.AddRange(patient1, patient2, patient3);
            // db.Appointments.AddRange(appointment1, appointment2, appointment3);  //це зайвий рядок, так як при додаванні в базу  лікарів і пацієнтів  Appointments-и додадуться автоматично як зв'язані сутності

            db.SaveChanges();
        }
    }
}
