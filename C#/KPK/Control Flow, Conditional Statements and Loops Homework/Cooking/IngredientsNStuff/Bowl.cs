namespace Cooking.IngredientsNStuff
{
    using System.Collections.Generic;

    internal class Bowl
    {
        private ICollection<Vegetable> ingredients;

        public Bowl()
        {
            this.ingredients = new List<Vegetable>();
        }

        public ICollection<Vegetable> Ingredients
        {
            get
            {
                return this.ingredients;
            }
        }

        public void Add(Vegetable vegetable)
        {
            this.ingredients.Add(vegetable);
        }
    }
}
