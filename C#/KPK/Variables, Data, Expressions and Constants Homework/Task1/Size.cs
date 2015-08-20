namespace Task1
{
    using System;

    public class Size
    {
        private double width, height;

        public Size(double w, double h)
        {
            this.Width = w;
            this.Height = h;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public static Size GetRotatedSize(Size s, double angleOfRotation)
        {
            var newWidth = Math.Abs(Math.Cos(angleOfRotation)) * s.Width + Math.Abs(Math.Sin(angleOfRotation)) * s.Height;
            var newHeight = Math.Abs(Math.Sin(angleOfRotation)) * s.Width + Math.Abs(Math.Cos(angleOfRotation)) * s.Height;
            return new Size(newWidth, newHeight);
        }
    }
}