namespace Students
{
    using System;

    public class StudentClassTest
    {
        public static void Main(string[] args)
        {
            Student gosho = new Student
            {
                FirstName = "Gosho",
                MiddleName = "G.",
                LastName = "Goshev",
                SocialSecurityNumber = 156,
                Adress = "Milano street",
                MobilePhone = "+359754635333",
                Email = "blqblq@abv.bg",
                Course = 1,
                University = University.SofiaUniversity,
                Faculty = Faculty.ComputerScience,
                Specialty = Specialty.ComputerScience
            };
            Student ivan = new Student
            {
                FirstName = "Ivan",
                MiddleName = "I.",
                LastName = "Ivanov",
                SocialSecurityNumber = 256,
                Course = 1,
                University = University.TechnicalUniversity,
                Faculty = Faculty.ComputerScience,
                Specialty = Specialty.ComputerScience
            };
            Student ivan2 = new Student
            {
                FirstName = "Ivan",
                MiddleName = "I.",
                LastName = "Ivanov",
                SocialSecurityNumber = 256,
                Course = 3,
                University = University.UNSS,
                Faculty = Faculty.FundamentalSciences,
                Specialty = Specialty.Management
            };

            Console.WriteLine(ivan);
            Console.WriteLine("~IVAN's HASHCODE: " + ivan.GetHashCode());
            Console.WriteLine(ivan2);
            Console.WriteLine("~IVAN2's HASHCODE: " + ivan2.GetHashCode());
            Console.WriteLine("~DOES IVAN EQUAL TO IVAN2: "+ivan.Equals(ivan2));
            Console.WriteLine("~DOES IVAN == IVAN2: "+(ivan == ivan2));
            Console.WriteLine(gosho);
            Console.WriteLine("~DOES IVAN == GOSHO: "+(ivan == gosho));
            Console.WriteLine("~GOSHO's HASHCODE: "+gosho.GetHashCode());

            Console.WriteLine();
            Student anotherGosho = (Student)gosho.Clone();
            Console.WriteLine("~MADE GOSHO's CLONE~");
            Console.WriteLine(anotherGosho);
            Student anotherIvan = (Student)ivan.Clone();
            Console.WriteLine("~MADE IVAN'S CLONE~");
            Console.WriteLine(anotherIvan);
            Console.WriteLine("~IVAN COMPARETO IVAN2~");
            Console.WriteLine(ivan.CompareTo(ivan2));
            Console.WriteLine("~IVAN COMPARETO GOSHO~");
            Console.WriteLine(ivan.CompareTo(gosho));
        }
    }
}
