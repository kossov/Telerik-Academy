namespace Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ShapesTest
    {
        public static void Main(string[] args)
        {
            Shape[] allShapes = new Shape[]
            {
                new Rectangle(5.5,10),
                new Square(5),
                new Triangle(6,9)
            };

            foreach (var shape in allShapes)
            {
                Console.WriteLine(shape.ToString());
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
