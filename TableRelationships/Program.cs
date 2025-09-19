using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

//1) Підхід TPH (Table per Hierarchy) (за-замовчуванням ) одна таблиця для всіх
//2) TPT (Table per Type) Кожен клас (базовий і похідний) має свою таблицю. Зв’язки реалізуються через JOIN. (зв'язок "один до одного" між базовим і похідним)
//для реалізації в конфігураціях похідних класів треба прописати: modelBuilder.ToTable("Customers");

//TPC (Table per Concrete Class) Кожен конкретний клас має свою таблицю, яка містить усі поля, включаючи успадковані.
//для реалізації в конфігурації батьківського класу треба прописати: builder.UseTpcMappingStrategy().ToTable("People");
//в конфігурації дочрніх класів треба прописати: builder.UseTpcMappingStrategy().ToTable("Customers");


namespace TableRelationships
{
    public class Program
    {
        static void Main(string[] args)
        {

            using var db = new HospitalContext();

            // 1) створюю адреси длікарів

            //Address doctoraddress1 = new Address()
            //{
            //    Street = "Veselaya",
            //    HouseNumber = 1
            //};

            //Address doctoraddress2 = new Address()
            //{
            //    Street = "Bogmi",
            //    HouseNumber = 2
            //};

            //Department department1 = new Department()
            //{
            //    Name = "HartIssues",
            //    Corpus = 1
            //};

            //Department department2 = new Department()
            //{
            //    Name = "Neurology",
            //    Corpus = 2
            //};
            //// 2) створюю лікарів, додаю в них створені вище адреси 

            //Doctor doctor1 = new Doctor()
            //{
            //    FirstName = "Anatoliy",
            //    LastName = "Fedorenko",
            //    Speciality = "LOR",
            //    Address = doctoraddress1,
            //    Phone = "0981111111",
            //    Department = department1
            //};

            //Doctor doctor2 = new Doctor()
            //{
            //    FirstName = "Sergiy",
            //    LastName = "Frolov",
            //    Speciality = "Anasteziolog",
            //    Address = doctoraddress2,
            //    Phone = "0981111122",
            //    Department = department2
            //};

            ////3) створюю адреси пацієнтів
            //Address patientAddress1 = new Address()
            //{
            //    //PatientId = 1,
            //    Street = "Zarichanskaya1",
            //    HouseNumber = 1
            //};

            //Address patientAddress2 = new Address()
            //{
            //    Street = "Zarichanskaya2",
            //    HouseNumber = 2
            //};

            //// 4) створюю пацієнтів. додаю їм створені вище адреси
            //Patient patient1 = new Patient()
            //{
            //    FirstName = "Olga",
            //    LastName = "Ivanova",
            //    DataOfBirth = new DateOnly(1980, 5, 1),
            //    Address = patientAddress1,
            //    Phone = "0981111133",
            //    Department = department1
            //};

            //Patient patient2 = new Patient()
            //{
            //    FirstName = "Tamara",
            //    LastName = "Krilova",
            //    DataOfBirth = new DateOnly(1985, 10, 10),
            //    Address = patientAddress2,
            //    Phone = "0981111144",
            //    Department = department1
            //};

            //Patient patient3 = new Patient()
            //{
            //    FirstName = "Vasilisa",
            //    LastName = "Ukolova",
            //    DataOfBirth = new DateOnly(1990, 11, 20),
            //    Phone = "0981111155",
            //    Department = department2,
            //    Address = new Address
            //    {
            //        City = "Kyiv",
            //        Street = "Hreschatyk",
            //        HouseNumber = 10
            //    }
            //};

            //// 5) створюю прийоми

            //Appointment appointment1 = new Appointment()
            //{
            //    Patient = patient1,
            //    Doctor = doctor1,
            //    CallingHome = false,
            //    Date = new DateTime(2025, 9, 3, 08, 00, 0)

            //};

            //Appointment appointment2 = new Appointment()
            //{
            //    Patient = patient2,
            //    Doctor = doctor2,
            //    CallingHome = false,
            //    Date = new DateTime(2025, 9, 3, 08, 10, 0)
            //};

            //Appointment appointment3 = new Appointment()
            //{
            //    Patient = patient3,
            //    Doctor = doctor1,
            //    CallingHome = true,
            //    Date = new DateTime(2025, 9, 3, 09, 00, 0)
            //};

            //Appointment appointment4 = new Appointment()
            //{
            //    Patient = patient1,
            //    Doctor = doctor2,
            //    CallingHome = true,
            //    Date = new DateTime(2025, 9, 5, 17, 00, 0)
            //};

            //Appointment appointment5 = new Appointment()
            //{
            //    Patient = patient1,
            //    Doctor = doctor1,
            //    CallingHome = true,
            //    Date = new DateTime(2025, 9, 10, 20, 00, 0)
            //};
            //doctor1.Appointments.AddRange([appointment1, appointment3, appointment5]);
            //doctor2.Appointments.AddRange([appointment2, appointment4]);

            //doctor1.Patients.AddRange([patient1, patient3]);// зв'язана сутність (PatientAddress) додасться автоматично
            //doctor2.Patients.AddRange([patient1, patient2]);                // так як вона була вказана при створенні головної сутності (екземплярів Patient)

            //db.Doctors.AddRange(doctor1, doctor2);
            //db.Patients.AddRange(patient1, patient2, patient3);
            //// db.Appointments.AddRange(appointment1, appointment2, appointment3);  //це зайвий рядок, так як при додаванні в базу  лікарів і пацієнтів  Appointments-и додадуться автоматично як зв'язані сутності

            //db.SaveChanges();

            ////var people = db.People.Where(p => p.Address != null).ToList();

            ////foreach (var person in people)
            ////{
            ////    Console.WriteLine($"{person.Id}, {person.LastName}, {person.FirstName}");
            ////    Console.WriteLine($"Address {person.Address.Street}, {person.Address.City}, {person.Address.HouseNumber}");
            ////}

            var doctors = db.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).Include(d => d.Patients).ToList();
            foreach (Doctor doctor in doctors)
            {
                Console.WriteLine($"Doctor {doctor.LastName}, {doctor.FirstName}");
                doctor.Appointments = doctor.Appointments.OrderByDescending(a => a.Date).ToList();
                foreach (var appointment in doctor.Appointments)
                {
                    Console.WriteLine(@$"had appointment {appointment.Date}
                    with patient {appointment.Patient.FirstName}
                    {appointment.Patient.LastName}");
                }
            }

            //   Console.WriteLine(doctors.ToQueryString());         

                //------------------*****-------------------------******-------------------------******---------------------------------------------
                //                              ТЕМА - ЗАВАНТАЖЕННЯ ДАНИХ
                // 1) Egear Loading (ЖАДІБНА)
                // дз1) Вивести лікар такий то на таку дату обслужив таких то пацієнтів
                foreach (Doctor doctor in doctors)
            {
                Console.WriteLine($"Doctor {doctor.FirstName} {doctor.LastName}  had appointment ");
                foreach (var appointment in doctor.Appointments)
                {
                    Console.WriteLine( $"{appointment.Date} with patient {appointment.Patient.FirstName} {appointment.Patient.LastName}" );
                }
            }

            // дз2) Пацієнт такий то - відвідав таких то лікарів
            var patients = db.Patients.Include(p => p.Address).Include(p => p.Appointments).ThenInclude(a => a.Doctor);
            foreach (var patient in patients)
            {
                Console.WriteLine($"Patient {patient.FirstName} {patient.LastName} visited ");
                foreach (var doctor in patient.Doctors)
                {
                    Console.WriteLine($" doctor {doctor.FirstName} {doctor.LastName}");
                }
            }

            //дз3) далі, на кожному лікареві знайти пацієнта в якого є позначка виклик додому - і вивести його адресу.
            foreach (Doctor doctor in doctors)
            {
                foreach (var item in doctor.Appointments)
                {
                    if (item.CallingHome == true && item.Patient.Address.HouseNumber != null)
                    {
                        Console.WriteLine($"Patients which have home appointments: {item.Patient.FirstName} {item.Patient.LastName}, adress: city - {item.Patient.Address.City}, street - {item.Patient.Address.Street}, house - {item.Patient.Address.HouseNumber}");
                    }
                }
            }

            //явне завантаження (EXPLICIT)
            //Адресу підвантажити Explicit Loading
            //var patientsWithHomeCalling = db.Patients.Where(p => p.Appointments[0].CallingHome  == true);

            //db.Entry((Person)patientsWithHomeCalling)
            //    .Reference(p => p.Address)
            //    .Load();

            //foreach (Doctor doctor in doctors)
            //{
            //    foreach (var item in doctor.Appointments)
            //    {
            //        if (item.CallingHome == true)
            //        {
            //            Console.WriteLine($"Doctors which have home appointments: {doctor.FirstName} {doctor.LastName} address: {patientsWithHomeCalling.First().Address}");
            //        }
            //    }
            //}


            //**********************************************************************






        }
    }
}
