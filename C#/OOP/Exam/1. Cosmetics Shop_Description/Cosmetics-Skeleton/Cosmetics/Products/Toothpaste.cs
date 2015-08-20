namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Toothpaste : Product, IToothpaste
    {
        private const int MinIngredientLength = 4;
        private const int MaxIngredientLength = 12;

        private string ingredients;

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
            private set
            {
                this.ingredients = value;
            }
        }

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            if (CheckIngredients(ingredients))
            {
                this.Ingredients = string.Join(", ", ingredients);
            }
        }

        private bool CheckIngredients(IList<string> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                if (ingredient.Length < MinIngredientLength || ingredient.Length > MaxIngredientLength)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Each ingredient must be between {0} and {1} symbols long!",
                        MinIngredientLength,
                        MaxIngredientLength));
                }
            }
            return true;
        }

        public override string Print()
        {
            return base.Print() + string.Format("  * Ingredients: {0}", this.Ingredients);
        }
    }
}
