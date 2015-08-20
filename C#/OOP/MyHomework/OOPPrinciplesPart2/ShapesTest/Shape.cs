namespace Shapes
{
    public abstract class Shape
    {
        public abstract double Width { get; set; }
        public abstract double Height { get; set; }

        public Shape(double side)
        {
            this.Height = side;
            this.Width = side;
        }

        public Shape(double w, double h)
        {
            this.Width = w;
            this.Height = h;
        }

        public virtual double CalculateSurface()
        {
            return 0.0;
        }
    }
}
