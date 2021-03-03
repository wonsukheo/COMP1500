using System;
using System.IO;

namespace Lab7
{
    public static class Lab7
    {
        public static bool PlayGame(uint[] array)
        {
            if (array.Length < 2 || array.Length <= array[0])
            {
                return false;
            }

            return RecursiveFunction(array, array.Length - 1);
        }

        public static bool RecursiveFunction(uint[] array, int index, int lastindex = 0)
        {
            // end condition
            if (index == array[0])
            {
                return true;
            }
            int j = 0;
            while (array[j++] == 0)
            {
                if (j == array.Length)
                {
                    return false;
                }
            }

            for (int i = 1; i < array.Length - 1; ++i)
            {
                if (i + array[i] == index || i - array[i] == index)
                {
                    if (i == lastindex)
                    {
                        array[index] = 0;
                        array[lastindex] = 0;
                        return RecursiveFunction(array, array.Length - 1);
                    }

                    return RecursiveFunction(array, i, index);
                }
            }

            if (index == array.Length -1)
            {
                return false;
            }

            array[index] = 0;
            return RecursiveFunction(array, array.Length - 1);
        }
    }
}
