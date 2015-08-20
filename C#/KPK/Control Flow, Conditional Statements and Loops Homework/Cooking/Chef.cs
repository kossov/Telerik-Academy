namespace Cooking
{
    using System;
    using IngredientsNStuff;

    public class Chef
    {
        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private void Cut(Vegetable vegetable)
        {
            vegetable.isCut = true;
        }

        private void Peel(Vegetable vegetable)
        {
            vegetable.isPeeled = true;
        }

        public void Cook()
        {
            Potato potato = GetPotato();
            Carrot carrot = GetCarrot();
            Bowl bowl = GetBowl();
            Peel(potato);
            Peel(carrot);
            Cut(potato);
            Cut(carrot);
            bowl.Add(carrot);
            bowl.Add(potato);
        }
    }
}
