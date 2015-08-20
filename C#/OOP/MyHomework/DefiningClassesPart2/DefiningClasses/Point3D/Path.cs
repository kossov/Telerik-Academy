namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        private List<Point3D> myPath;

        public Path()
        {
            this.myPath = new List<Point3D>();
        }

        public List<Point3D> MyPath
        {
            get
            {
                return this.myPath;
            }
        }


    }
}
