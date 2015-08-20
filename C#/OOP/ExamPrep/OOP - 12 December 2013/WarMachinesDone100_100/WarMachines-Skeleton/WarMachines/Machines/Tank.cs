namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        public bool DefenseMode { get; set; }

        public Tank(string name, double attack, double defense) : base(name,attack,defense)
        {
            this.HealthPoints = 100;
            this.AttackPoints = attack - 40;
            this.DefensePoints = defense + 30;
            this.DefenseMode = true;
        }

        public void Attack(string target)
        {
            this.Targets.Add(target);
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("\n- {0}", this.Name);
            result.AppendLine();
            result.AppendFormat(@" *Type: {0}
 *Health: {1}
 *Attack: {2}
 *Defense: {3}
 *Targets: {4}
 *Defense: {5}", this.GetType().Name, this.HealthPoints, this.AttackPoints, this.DefensePoints, this.Targets.Count > 0 ? string.Join(", ", this.Targets) : "None", this.DefenseMode == true ? "ON" : "OFF");
            return result.ToString();
        }
    }
}
