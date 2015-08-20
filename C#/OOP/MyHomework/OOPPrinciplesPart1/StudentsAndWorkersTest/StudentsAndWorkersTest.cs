using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndWorkers
{
    class StudentsAndWorkersTest
    {
        static void Main(string[] args)
        {
            //Student gosho = new Student("Gosho", "Goshev",6);
            //Console.WriteLine(gosho.Grade);
            //Worker gogo = new Worker("Gogo", "Gogev");
            //Console.WriteLine(gogo);
            //gosho.Grade = Grade.Average;
            //Console.WriteLine(gosho.Grade);
            //gosho.Grade = (Grade)2;
            //Console.WriteLine(gosho.Grade);
            //gosho.Grade = Grade.Excellent;
            //Console.WriteLine(gosho.Grade);

            // itialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
            Console.WriteLine("MY TEN STUDENTS:");
            List<Student> myTenStudents = new List<Student>
            {
                new Student("Gosho","Goshev",Grade.Excellent),
                new Student("Ivaylo","Petkov",2),
                new Student("Dragan","Goshev",Grade.Average),
                new Student("Petkan","Petkov",3),
                new Student("Ivanka","Georgieva",Grade.Good),
                new Student("Stanka","Lukanka",4),
                new Student("Gryiu","Gruiev",Grade.Poor),
                new Student("Iordanka","Petkova",5),
                new Student("Slon","Golqm",Grade.VerryGood),
                new Student("Neznam","Neznamchev",6),
            };
            myTenStudents.ForEach(Console.WriteLine);
            myTenStudents = myTenStudents.OrderBy(x => x.Grade).ToList();
            Console.WriteLine("\n~~Students after sort~~");
            myTenStudents.ForEach(Console.WriteLine);

            // Initialize a list of 10 workers and sort them by money per hour in descending order.
            Console.WriteLine("\nMY TEN WORKERS:");
            List<Worker> myTenWorkers = new List<Worker>
            {
                new Worker("Brat","Stiga",250.5,13),
                new Worker("Stes","Imena",920,20),
                new Worker("Veche","Naistina",360.5,10),
                new Worker("Nemoga","DaGi",2010,1),
                new Worker("Izmislqm","Stiga",600.99,15),
                new Worker("Stigaa","Daje",315,22),
                new Worker("Taq","Glupost",211,26),
                new Worker("Kak","MiHrumna",645,17),
                new Worker("Neznam","Neznamm",766,25),
                new Worker("Posledniq","Yess",421,27)
            };
            myTenWorkers.ForEach(Console.WriteLine);
            myTenWorkers = myTenWorkers.OrderByDescending(x => x.MoneyPerHour()).ToList();
            Console.WriteLine("\n~~Workers after sort~~");
            myTenWorkers.ForEach(Console.WriteLine);

            Console.WriteLine();
            Console.WriteLine("~~~~MERGING LISTS AND SORTING BY FIRST AND LASTNAME~~~~~");
            List<Human> mergedLists = new List<Human>();
            mergedLists.AddRange(myTenStudents);
            mergedLists.AddRange(myTenWorkers);
            mergedLists = mergedLists
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();
            mergedLists.ForEach(Console.WriteLine);
        }
    }
}
