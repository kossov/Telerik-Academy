namespace Person
{
    using System;

    public class PersonTest
    {
        public static void Main(string[] args)
        {
            Person gosho = new Person("Gosho");
            Person mariika = new Person("Mariika", 21);
            Console.WriteLine(gosho);
            Console.WriteLine(mariika);
            Person ivancho = new Person("Ivanchy", 0);
        }
    }
}
