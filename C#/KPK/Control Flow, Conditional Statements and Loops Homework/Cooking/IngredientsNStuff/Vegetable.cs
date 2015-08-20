namespace Cooking.IngredientsNStuff
{
    internal class Vegetable
    {
        public Vegetable()
        {
            this.isCut = false;
            this.isPeeled = false;
        }

        public bool isPeeled { get; set; }
        public bool isCut { get; set; }
    }
}
