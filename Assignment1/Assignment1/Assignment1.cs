using System.IO;
using System;

namespace Assignment1
{
    public static class Assignment1
    {
        public static void PrintIntegers(StreamReader input, StreamWriter output, int width)
        {
            uint[] number = new uint[5];

            for (int i = 0; i < 5; ++i)
            {
                number[i] = uint.Parse(input.ReadLine());
            }

            int formatWidth = 10;
            if (width > 10)
            {
                formatWidth = width;
            }

            output.WriteLine("oct".PadLeft(formatWidth) + " " + "dec".PadLeft(formatWidth) + " " + "hex".PadLeft(formatWidth));

            for (int i = 0; i < 5; ++i)
            {
                output.Write(Convert.ToString(number[i], 8).PadLeft(formatWidth));
                output.Write(" ");
                output.Write(Convert.ToString(number[i]).PadLeft(formatWidth));
                output.Write(" ");
                output.WriteLine(Convert.ToString(number[i], 16).PadLeft(formatWidth));
            }
        }

        public static void PrintStats(StreamReader input, StreamWriter output)
        {
            double[] number = new double[5];

            for (int i = 0; i < 5; ++i)
            {
                number[i] = double.Parse(input.ReadLine());
            }

            for (int i = 0; i < 5; ++i)
            {
                string printNumber = string.Format("{0:f3}", number[i]);
                
                output.WriteLine("{0,25}", printNumber);
            }

            double min = number[0];
            for (int i = 1; i < 5; ++i)
            {
                if (number[i] < min)
                {
                    min = number[i];
                }
            }
            string minformatted = string.Format("{0:f3}", min);

            double max = number[0];
            for (int i = 1; i < 5; ++i)
            {
                if (number[i] > max)
                {
                    max = number[i];
                }
            }
            string maxformatted = string.Format("{0:f3}", max);


            double sum = 0;
            for (int i = 0; i < 5; ++i)
            {
                sum += number[i];
            }
            string sumformatted = string.Format("{0:f3}", sum);
           
            double avg = sum / 5;
            string avgformatted = string.Format("{0:f3}", avg);

            output.WriteLine("{0,-7} {1,17}", "Min", minformatted);
            output.WriteLine("{0,-7} {1,17}", "Max", maxformatted);
            output.WriteLine("{0,-7} {1,17}", "Sum", sumformatted);
            output.WriteLine("{0,-7} {1,17}", "Average", avgformatted);
        }
    }
}
