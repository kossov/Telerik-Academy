namespace AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AnimalHierarchyTest
    {
        static void Main(string[] args)
        {
            List<Cat> allCats = new List<Cat>
            {
                new Cat(3,"Pisana",GenderEnumerator.Female),
                new Cat(5,"Pisan",GenderEnumerator.Male)
            };
            allCats.ForEach(Console.WriteLine);

            List<Dog> allDogs = new List<Dog>
            {
                new Dog(10,"Danny",GenderEnumerator.Male)
            };
            allDogs.ForEach(Console.WriteLine);

            List<Frog> allFrogs = new List<Frog>
            {
                new Frog(15,"Jabyrana",GenderEnumerator.Female)
            };
            allFrogs.ForEach(Console.WriteLine);
        }
    }
}
