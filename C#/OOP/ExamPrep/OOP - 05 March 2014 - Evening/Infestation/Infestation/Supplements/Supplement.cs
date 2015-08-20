using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation.Supplements
{
    public abstract class Supplement : ISupplement
    {
        public int PowerEffect { get; protected set; }

        public int HealthEffect { get; protected set; }

        public int AggressionEffect { get; protected set; }

        public Supplement(int power, int health, int agression)
        {
            this.PowerEffect = power;
            this.HealthEffect = health;
            this.AggressionEffect = agression;
        }

        public virtual void ReactTo(ISupplement otherSupplement)
        {

        }
    }
}
