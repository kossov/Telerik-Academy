using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem.Models
{
    public class Lion : Animal, ICarnivore
    {
        private const int LionSize = 6;

        public Lion(string name, Point location)
            : base(name, location, LionSize)
        {

        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal.Size * 2 <= this.Size * 2)
                {
                    this.Size += 1;
                    return animal.GetMeatFromKillQuantity();
                }
                // bite size logic return p.GetEatenQuantity(this.biteSize);
            }
            return 0;
        }
    }
}
