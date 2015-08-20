namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;

    public class Fighter : Machine,IFighter
    {
        public bool StealthMode { get; set; }

        public Fighter(string name, double attack, double defense, bool stealthMode)
            : base(name, attack, defense)
        {
            this.HealthPoints = 200;
            this.StealthMode = stealthMode;
        }

        public void ToggleStealthMode()
        {
            if (this.StealthMode == true)
            {
                this.StealthMode = false;
            }
            else
            {
                this.StealthMode = true;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("\n- {0}\n", this.Name);
            result.AppendFormat(@" *Type: {0}
 *Health: {1}
 *Attack: {2}
 *Defense: {3}
 *Targets: {4}
 *Stealth: {5}", this.GetType().Name, this.HealthPoints, this.AttackPoints, this.DefensePoints, this.Targets.Count > 0 ? string.Join(", ", this.Targets) : "None", this.StealthMode == true ? "ON" : "OFF");
            return result.ToString();
        }
    }
}
