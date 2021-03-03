using System;
using System.IO;

namespace Lab7
{
    public static class Lab7
    { 
        public static bool PlayGame(uint[] array)
        {
            if (array.Length < 2 || array.Length <= array[0] )
            {
                return false;
            }

            return recursiveFunction(array, array.Length - 1);
        }
        
        public static bool recursiveFunction(uint[] array, int index)
        {          
            // end condition
            if (index == array[0])
            {
                return true;
            }

            for (int i = 1; i < array.Length - 1; ++i)
            {
                if (i + array[i] == index || i - array[i] == index)
                {
                    return recursiveFunction(array, i);
                }             
            }

            return false;
        }
    }
}
