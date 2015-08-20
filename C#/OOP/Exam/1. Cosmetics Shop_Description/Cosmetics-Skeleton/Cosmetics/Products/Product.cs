namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public abstract class Product : IProduct
    {
        private const int MinNameLength = 3;
        private const int MaxNameLength = 10;
        private const int MinBrandNameLength = 2;
        private const int MaxBrandNameLength = 10;

        private string name;
        private string brand;

        public decimal Price { get; protected set; }
        public GenderType Gender { get; protected set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentOutOfRangeException("",string.Format("Product name must be between {0} and {1} symbols long!", MinNameLength, MaxNameLength));
                }
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            protected set
            {
                if (value.Length < MinBrandNameLength || value.Length > MaxBrandNameLength)
                {
                    throw new ArgumentOutOfRangeException("",string.Format("Product brand must be between {0} and {1} symbols long!", MinBrandNameLength, MaxBrandNameLength));
                }
                    this.brand = value;
            }
        }

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Gender = gender;
            this.Price = price;
            
        }

        public virtual string Print()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat(@"- {0} - {1}:
  * Price: ${2}
  * For gender: {3}
", this.Brand, this.Name, this.Price, this.Gender);
            return result.ToString();
        }
    }
}
