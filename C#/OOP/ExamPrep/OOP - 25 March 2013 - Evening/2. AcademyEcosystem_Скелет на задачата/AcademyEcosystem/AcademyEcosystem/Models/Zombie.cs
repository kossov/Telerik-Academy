using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem.Models
{
    public class Zombie : Animal
    {
        private const int MeatToGive = 10;

        public Zombie(string name,Point position)
            : base(name, position, int.MinValue) 
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            this.IsAlive = true;
            return MeatToGive;
        }
    }
}
