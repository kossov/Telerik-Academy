namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        public string Name { get; set; }

        public IPilot Pilot { get; set; }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; set; }

        public double DefensePoints { get; set; }

        public IList<string> Targets { get; set; }

        public Machine(string name,double attack, double defense)
        {
            Targets = new List<string>();
            this.Name = name;
            this.AttackPoints = attack;
            this.DefensePoints = defense;
        }


        public void Attack(string target)
        {
            throw new NotImplementedException();
        }
    }
}
