namespace Schools
{
    using System;
    using System.Collections.Generic;

    public class SchoolTest
    {
        static void Main(string[] args)
        {
            Discipline[] allDisciplines = new Discipline[]
            {
                new Discipline("Mathematics",15,50),
                new Discipline("Principles of Mechanical Engineering",20,20),
                new Discipline("Industrial Management",10,10),
                new Discipline("Fluid Mechanics",25,70),
                new Discipline("Operations Research",30,40)
            };
            List<Teacher> allTeachers = new List<Teacher>
            {
                new Teacher("Ivan Ivanov",allDisciplines),
                new Teacher("Dragan Petkanov",allDisciplines),
                new Teacher("Ivancho Goshev",allDisciplines),
                new Teacher("Goshko Goshev",allDisciplines)
            };
            List<Student> allStudents = new List<Student>
            {
                new Student("Petka",1),
                new Student("Draganka",2),
                new Student("Zlatka",3),
                new Student("Gancho",4),
                new Student("Voncho",5)
            };
            List<Class> allClasses = new List<Class>
            {
                new Class("1",allTeachers,allStudents)
            };

            School tues = new School(allClasses);

            foreach (var item in allClasses)
            {
                Console.WriteLine(item);
            }
        }
    }
}
