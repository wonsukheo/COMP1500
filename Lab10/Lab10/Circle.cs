using System;

namespace Lab10
{
    public class Circle
    {
        public uint Radius { get; private set; }

        public uint Diameter { get; private set; }

        private const double mPI = 3.1415926535897931;
        public Circle(uint radius)
        {
            Radius = radius;

            Diameter = radius * 2;
        }
        public double GetCircumference()
        {
            if (Radius == 0)
            {
                return 0.0000;
            }

            double perimeter = Radius * 2 * mPI;

            return (int)(perimeter * 1000 + 0.5) / (double)1000;
        }

        public double GetArea()
        {
            double area = Radius * Radius * PI;

            return (int)(area * 1000 + 0.5) / (double)1000;
        }
    }
}
