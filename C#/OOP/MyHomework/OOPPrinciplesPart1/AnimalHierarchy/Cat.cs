using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class Cat : Animal
    {
        private int age;
        private string name;
        private GenderEnumerator gender;
        private string kittenOrTomcat;

        public override int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Wrong age!");
                }
                this.age = value;
            }
        }

        public override string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length <= 2)
                {
                    throw new ArgumentException("Too short Name!");
                }
                this.name = value;
            }
        }

        public override GenderEnumerator Sex
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
                if (value == GenderEnumerator.Male)
                {
                    this.kittenOrTomcat = "TOMCAT";
                }
                else
                {
                    this.kittenOrTomcat = "KITTEN";
                }
            }
        }

        public Cat(int age, string name, GenderEnumerator gender) : base(age, name, gender) { }

        public override string ProduceSound()
        {
            return string.Format("I am {0} and I am a {1}! Meowwww",this.Name,this.kittenOrTomcat);
        }
    }
}
