namespace AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Animal : ISound
    {
        public abstract int Age { get; set; }
        public abstract string Name { get; set; }
        public abstract GenderEnumerator Sex { get; set; }

        public Animal(int age, string name, GenderEnumerator gender)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = gender;
        }

        public static int AverageAge(IEnumerable<Animal> animals)
        {
            int age = 0;
            age = (int)animals.Average(a => a.Age);
            return age;
        }

        public virtual string ProduceSound()
        {
            return "I am Animal";
        }

        public override string ToString()
        {
            return this.ProduceSound();
        }
        }
}
