using DataBase.Entities;
using System.Collections.Generic;

namespace TableRelationships
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ПРИКЛАДИ ЗВ'ЯЗКІВ ТУТ:
            //1) Персона її адреса  Один до одного  Строатегія Каскад
            //Команда - Гравець - 1 до багатьох  -стратегія SetNull
            //Вчитель - Учень - багато до багатьох


            using var db = new DataBaseContext();

            //1) Персона її адреса  Один до одного   Строатегія Каскад
            Person person = new Person()
            {
                FirstName = "Ludmila",
                LastName = "Solovey",
                Address = new Address()
                {
                    City = "Lviv",
                    Country = "Ukr",
                    Street = "Ivana Franka"
                }
            };

            db.Add(person);
            db.SaveChanges();
            //------------------------------------------end 1)


            //2) Команда - Гравець - 1 до багатьох  -стратегія SetNull

            Team team1 = new Team()
            {
                Name = "Dinamo"
            };

            Player player1 = new Player()
            {
                FirstName = "Shevchenco",
                LastName = "Sergiy",
                Team = team1
            };

            Player player2 = new Player()
            {
                FirstName = "Dubrov",
                LastName = "Evgen",
                Team = team1
            };

            db.Players.AddRange(player1, player2);
            db.SaveChanges();

            //------------------------------------------------------------------end 2)

            //3) Вчитель - Учень - багато до багатьох 

            Pupil pupil1 = new Pupil()
            {
                FirstName = "Andriy",
                LastName = "Strukov",
                Patronymic = "Sergiyovich"
            };

            Pupil pupil2 = new Pupil()
            {
                FirstName = "Segiy",
                LastName = "Barbara",
                Patronymic = "Ivanovich"
            };

            Pupil pupil3 = new Pupil()
            {
                FirstName = "Petro",
                LastName = "Taran",
                Patronymic = "Petrovich"
            };

            Teacher teacher1 = new Teacher()
            {
                FirstName = "Galina",
                LastName = "Mudrack",
                Patronymic = "Ivanovivna"
            };

            Teacher teacher2 = new Teacher()
            {
                FirstName = "Tetiana",
                LastName = "Volkova",
                Patronymic = "Evgenivna"
            };

            //pupil1.Teachers.Add(teacher1);
            //pupil1.Teachers.Add(teacher2);


            pupil1.Teachers.AddRange([teacher1, teacher2]);
            teacher1.Pupils.AddRange([pupil1, pupil2]);

            pupil2.Teachers.Add(teacher2);
            pupil3.Teachers.Add(teacher2);

            db.Pupils.AddRange(pupil1, pupil2, pupil3);
            db.SaveChanges();

        }
    }
}
