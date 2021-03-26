using System;

namespace Lab10
{
    public class RightTriangle
    {
        public uint Width { get; private set; }
        public uint Height { get; private set; }
        public RightTriangle(uint width, uint height)
        {
            Width = width;
            Height = height;
        }

        public double GetPerimeter()
        {
            if (Width == 0 || Height == 0)
            {
                return 0.0000;
            }

            uint sqrt = (Width * Width) + (Height * Height);

            double thirdSide = Math.Sqrt(sqrt);

            double perimeter = Width + Height + thirdSide;

            return (int)(perimeter * 1000 + 0.5) / (double)1000;
        }

        public double GetArea()
        {
            double area = Width * Height / 2;

            return (int)(area * 1000 + 0.5) / (double)1000;
        }
    }
}
