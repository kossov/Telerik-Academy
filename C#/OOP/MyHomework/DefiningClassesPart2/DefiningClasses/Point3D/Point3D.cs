namespace DefiningClasses
{
    using System;

    public struct Point3D
    {
        private static readonly Point3D startPoint;

        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public static Point3D StartPoint
        {
            get
            {
                return startPoint;
            }
        }

        static Point3D()
        {
            startPoint = new Point3D(0, 0, 0);
        }

        public Point3D(double x, double y, double z) : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return string.Format("[{0},{1},{2}]",this.x,this.y,this.z);
        }
    }
}
