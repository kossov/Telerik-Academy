namespace RefactorIfs
{
    internal class Potato
    {
        public Potato()
        {
            this.IsPeeled = false;
            this.IsRotten = false;
        }

        public bool IsPeeled { get; set; }

        public bool IsRotten { get; set; }

        public void Cook()
        {
            this.IsPeeled = true;
        }
    }
}
