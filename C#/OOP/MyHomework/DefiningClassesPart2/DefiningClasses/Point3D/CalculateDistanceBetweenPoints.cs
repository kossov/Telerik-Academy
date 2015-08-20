namespace DefiningClasses
{
    using System;

    public static class DistanceBetweenPoints
    {
        public static double CalculateDistance(Point3D a, Point3D b)
        {
            return Math.Sqrt(Math.Pow((a.x - b.x), 2) + Math.Pow((a.y - b.y), 2) + Math.Pow((a.z - b.z), 2));
        }
    }
}
