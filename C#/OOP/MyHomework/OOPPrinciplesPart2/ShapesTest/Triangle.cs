namespace Shapes
{
    using System;

    public class Triangle : Shape
    {
        private double width;
        private double height;

        public override double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Wrong width value!");
                }
                this.width = value;
            }
        }

        public override double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Wrong height value!");
                }
                this.height = value;
            }
        }

        public Triangle(double width, double height) : base(width, height) { }

        public override double CalculateSurface()
        {
            return (this.Height * this.Width) / 2;
        }

        public override string ToString()
        {
            return "I am a Triangle!";
        }
    }
}
