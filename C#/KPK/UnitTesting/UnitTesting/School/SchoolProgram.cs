namespace School
{
    using System;

    public class SchoolProgram
    {
        public static void Main()
        {
            ////Write three classes: Student, Course and School. Students should have name and unique number 
            ////(inside the entire School). Name can not be empty and the unique number is between 10000 
            ////and 99999. Each course contains a set of students. Students in a course should be less than 
            ////30 and can join and leave courses.

            var course = new Course("Mathematics");

            course.Add(new Student("Gogo", "Petrov", 13154));
            course.Add(new Student("Ivan", "Ivanov", 13274));
            course.Add(new Student("Dimitar", "Asparuhov", 11334));

            Console.WriteLine();
        }
    }
}