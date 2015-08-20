namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Shampoo : Product, IShampoo
    {
        public uint Milliliters { get; private set; }
        public UsageType Usage { get; private set; }

        public Shampoo(string name, string brand,decimal price, GenderType gender, uint mililiters, UsageType usage)
            : base(name, brand,price, gender)
        {
            this.Milliliters = mililiters;
            this.Price = price * mililiters;
            this.Usage = usage;
        }

        public override string Print()
        {
            return base.Print() + string.Format(@"  * Quantity: {0} ml
  * Usage: {1}",this.Milliliters,this.Usage);
        }
    }
}
