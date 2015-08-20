namespace EMDL_LINQ
{
    using EMDL_LINQ.Students;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class AllBeginsHere
    {
        static void Main(string[] args)
        {
            Student[] allStudents = 
            {
                new Student("Gosho", "Goshev",21),
                new Student("Ivan", "Ivanov",17),
                new Student("Petkan", "Draganov",18)
            };
            Console.WriteLine("OUR INITIAL STUDENTS ARRAY:\n");
            foreach (var student in allStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("\nHERE IT ALL BEGINS\n");

            // 3. Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
            var specialStudents = FirstBeforeLast(allStudents);
            Console.WriteLine("~~~Testing FirstBeforeLastMethod~~~\n" + specialStudents[0].FirstName + " " + specialStudents[0].LastName);

            // 4. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
            IEnumerable<string> specialAgedStudents = allStudents.Where(st => st.Age >= 18 && st.Age <= 24).Select(st => st.FirstName + " " + st.LastName);
            Console.WriteLine("~~~Testing specialAgedStudents(18~24)~~~");
            foreach (var item in specialAgedStudents)
            {
                Console.WriteLine(item);
            }

            // 5. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.
            var sortedStudents = allStudents
                .OrderByDescending(st => st.FirstName)
                .ThenByDescending(st => st.LastName);
            Console.WriteLine("~~~Testing OderBy() and ThenBy() in descending order~~~");
            foreach (var item in sortedStudents)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

            /* 9. Create a class Student with properties FirstName, LastName, FN, Tel, Email, Marks (a List), GroupNumber.
                  Create a List<Student> with sample students. Select only the students that are from group number 2.
                  Use LINQ query. Order the students by FirstName. */
            Console.WriteLine(new string('.', 50));
            Console.WriteLine("\nHERE STARTS ANOTHER LIST OF STUDENTS\n");
            List<Student> anotherListOfStudents = new List<Student>
            {
                new Student("Dragan", "Soshev",15,"123406432","02 111 111 11","as@yahoo.com",new List<int>{ 3 , 2, 3 , 2 },2),
                new Student("Ivanka", "Koleva",16,"123406432","+359 222 222 22","abs@yahoo.com",new List<int>{ 4 , 5, 6 , 2 },1),
                new Student("Trubadur", "Kolev",17,"123405432","02 333 333 33","avqs@abv.bg",new List<int>{ 3 },1),
                new Student("Dragan", "Petkanov",16,"123405432","02 444 444 44","qwes@abv.bg",new List<int>{ 6 , 6},2),
                new Student("Petkan", "Draganov",23,"123406432","+359 555 555 55","swqes@abv.bg",new List<int>{ 2,2 },1),
                new Student("Zlatka", "Slatka",30,"123405432","+359 666 666 66","tssq@abv.bg",new List<int>{ 5 , 6, 3 , 3 },2)
            };
            Console.WriteLine("~~Testing onlyWithGroupNumber2~~");
            var onlyWithGrpNumbTwo =
                from student in anotherListOfStudents
                where (student.GroupNumber == 2)
                orderby student.FirstName
                select student;
            foreach (var item in onlyWithGrpNumbTwo)
            {
                Console.WriteLine(item + " Group number: " + item.GroupNumber);
            }
            Console.WriteLine();

            // 10. Implement the previous using the same query expressed with extension methods.
            Console.WriteLine("~~Testing onlyWithGroupNumber2 using Extention Method~~");
            var onlyWithGroupNumber2Extention = anotherListOfStudents.onlyWithGroupNumber2LINQ();
            foreach (var item in onlyWithGroupNumber2Extention)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // 11. Extract all students that have email in abv.bg. Use string methods and LINQ.
            Console.WriteLine("~~Testing Extracted by Email(abv.bg)~~");
            var extractByEmail =
                from student in anotherListOfStudents
                where (student.Email.Contains("abv.bg"))
                select student;
            foreach (var item in extractByEmail)
            {
                Console.WriteLine(item + " " + item.Email);
            }
            Console.WriteLine();

            // 12. Extract all students with phones in Sofia. Use LINQ.
            Console.WriteLine("~~Testing Sofia Phones~~");
            var allPhonesSofia =
                from student in anotherListOfStudents
                where (student.Tel.StartsWith("02"))
                select student;
            foreach (var item in allPhonesSofia)
            {
                Console.WriteLine(item + " " + item.Tel);
            }
            Console.WriteLine();

            // 13. Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks.
            Console.WriteLine("~~Testing Atleast One Excellent(6) and Anonymous Class~~");
            var excellentStudents =
                from student in anotherListOfStudents
                where (student.Marks.Contains(6))
                select student;
            foreach (var student in excellentStudents)
            {
                Console.WriteLine(new { Fullname = student.FirstName + " " + student.LastName, Marks = string.Join(", ", student.Marks) });
            }
            Console.WriteLine();

            // 14. Write down a similar program that extracts the students with exactly two marks "2". Use extension methods.
            Console.WriteLine("~~Testing students that have exactly two marks '2'~~");
            var allStudentsWithTwoMarks2 = anotherListOfStudents.ExtractWithTwo2();
            foreach (var item in allStudentsWithTwoMarks2)
            {
                Console.WriteLine(item + " Marks: " + string.Join(", ",item.Marks));
            }
            Console.WriteLine();

            // 15. Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
            Console.WriteLine("~~Testing Students that enrolled in 2006~~");
            var allStudentsFrom2006 =
                from student in anotherListOfStudents
                where (student.FN[4].Equals('0') && student.FN[5].Equals('6'))
                select student;
            foreach (var item in allStudentsFrom2006)
            {
                Console.WriteLine(item + " " + item.FN);
            }
            Console.WriteLine();
        }

        public static Student[] FirstBeforeLast(Student[] arr)
        {
            var specialStudents = arr.Where(student => student.FirstName.ToLower().CompareTo(student.LastName.ToLower()) < 0).Select(x => x);
            return specialStudents.ToArray();

            //                                         or
            //var firstBeforeLastStudents =
            //    from student in allStudents
            //    where (student.FirstName.ToLower().CompareTo(student.LastName.ToLower()) < 0)
            //    select student;
        }
    }
}
