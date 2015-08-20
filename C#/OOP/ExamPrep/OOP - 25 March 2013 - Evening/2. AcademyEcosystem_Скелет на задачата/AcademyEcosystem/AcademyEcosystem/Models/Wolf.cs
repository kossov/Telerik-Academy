using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem.Models
{
    public class Wolf : Animal, ICarnivore
    {
        private const int WolfSize = 4;

        public Wolf(string name, Point location)
            : base(name,location,WolfSize)
        {
            
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal.Size <= this.Size)
                {
                    return animal.GetMeatFromKillQuantity();
                }
                else if (animal.State == AnimalState.Sleeping)
                {
                    return animal.GetMeatFromKillQuantity();
                }
                // bite size logic return p.GetEatenQuantity(this.biteSize);
            }
            return 0;
        }
    }
}
