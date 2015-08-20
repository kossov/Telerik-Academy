namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Cosmetics.Contracts;

    public class Category : ICategory
    {
        private const int MinCategoryNameLength = 2;
        private const int MaxCategoryNameLength = 15;

        private string name;
        private ICollection<IProduct> allCosmetics;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < MinCategoryNameLength || value.Length > MaxCategoryNameLength)
                {
                    throw new ArgumentOutOfRangeException("", string.Format("Category name must be between {0} and {1} symbols long!", MinCategoryNameLength, MaxCategoryNameLength));
                }
                    this.name = value;
            }
        }

        public Category(string name)
        {
            this.Name = name;
            allCosmetics = new List<IProduct>();
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            if (cosmetics != null)
            {
                allCosmetics.Add(cosmetics);
            }
            else
            {
                throw new ArgumentNullException("Null Cosmetics product!");
            }
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!allCosmetics.Remove(cosmetics))
            {
                throw new ArgumentOutOfRangeException("",string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
            }
            else
            {
                allCosmetics.Remove(cosmetics);
            }
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0} category - {1} {2} in total\n", this.Name, this.allCosmetics.Count, this.allCosmetics.Count == 1 ? "product" : "products");
            if (this.allCosmetics.Count > 0)
            {
                this.allCosmetics = allCosmetics.OrderBy(c => c.Brand).ThenByDescending(c => c.Price).ToList();
                foreach (var cosmetics in allCosmetics)
                {
                    result.AppendLine(cosmetics.Print());
                }
            }
            return result.ToString().TrimEnd();
        }
    }
}
