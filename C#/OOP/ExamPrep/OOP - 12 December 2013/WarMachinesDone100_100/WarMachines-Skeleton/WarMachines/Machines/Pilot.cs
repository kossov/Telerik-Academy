namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private ICollection<IMachine> machines;

        public string Name { get; set; }

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            this.machines = this.machines.OrderBy(m => m.HealthPoints).ThenBy(m => m.Name).ToList();
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0} - ",this.Name);
            if (this.machines.Count == 0)
            {
                result.Append("no machines");
            }
            else
            {
                result.AppendFormat("{0} {1}", this.machines.Count, this.machines.Count > 1 ? "machines" : "machine");
            }
            foreach (IMachine machine in this.machines)
            {
                result.Append(machine);
            }
            return result.ToString();
        }
    }
}
