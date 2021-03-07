using System;
using System.IO;

namespace Lab7
{
    public static class Lab7
    {
        public static bool PlayGame(uint[] array)
        {
            int arrayLength = array.Length;

            uint[] copyArray = new uint[arrayLength];

            for (int i = 0; i < arrayLength - 1; i++)
            {
                copyArray[i] = array[i];
            }
            //check pre-condition
            if (arrayLength < 2 || arrayLength <= array[0])
            {
                return false;
            }
            
            return Move(copyArray, arrayLength - 1);
        }

        public static bool Move(uint[] array, int startIndex, int previousIndex = 0)
        {
            // end condition
            if (startIndex == array[0])
            {
                return true;
            }

            int i = 1;
            int arrayLength = array.Length;

            while (array[i++] == 0)
            {
                if (i == arrayLength)
                {
                    return false;
                }
            }

            for (i = 1; i < arrayLength - 1; ++i)
            {
                if (i + array[i] == startIndex || i - array[i] == startIndex)
                {
                    if (array[i] == 0)
                    {
                        continue;
                    }

                    if (i == previousIndex)
                    {
                        array[startIndex] = 0;
                        return Move(array, arrayLength - 1);
                    }
                    
                    return Move(array, i, startIndex);
                }
            }
            
            if (startIndex == arrayLength - 1)
            {
                return false;
            }

            array[startIndex] = 0;
            return Move(array, arrayLength - 1);
        }
    }
}
