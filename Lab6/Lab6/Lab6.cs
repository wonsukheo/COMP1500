using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    public static class Lab6
    {
        public static int[,] Rotate90Degrees(int[,] data)
        {
            int rowSize = data.GetLength(0);
            int columnSize = data.GetLength(1);

            int[,] rotated90Array = new int[columnSize, rowSize];
            
            for (int i = 0; i < columnSize; ++i)
            {
                for (int j = 0; j < rowSize; ++j)
                {
                    rotated90Array[i, j] = data[(rowSize - 1) - j, i];
                }
            }

            return rotated90Array;
        }

        public static void TransformArray(ref int[,] data, EMode rotateMode)
        {
            int rowSize = data.GetLength(0);
            int columnSize = data.GetLength(1);
            int[,] temporaryData = new int[rowSize, columnSize];

            switch (rotateMode)
                {
                    case EMode.HorizontalMirror:
                        for (int i = 0; i < rowSize; ++i)
                        {
                            for (int j = 0; j < columnSize; ++j)
                            {
                                temporaryData[i, j] = data[i, columnSize - 1 - j];
                            }
                        }
                        data = temporaryData;
                        break;

                    case EMode.VerticalMirror:
                        for (int i = 0; i < rowSize; ++i)
                        {
                            for (int j = 0; j < columnSize; ++j)
                            {
                                temporaryData[i, j] = data[rowSize - 1 - i, j];
                            }
                        }
                        data = temporaryData;
                        break;

                    case EMode.DiagonalShift:
                        for (int i = 0; i < rowSize; ++i)
                        {
                            for (int j = columnSize - 1; j > 0; --j)
                            {
                                temporaryData[i, j] = data[i, j - 1];
                            }
                           
                            temporaryData[i, 0] = data[i, columnSize - 1];
                        }

                        int[] temporaryArray = new int[columnSize];

                        for (int j = 0; j < columnSize; ++j)
                        {
                            temporaryArray[j] = temporaryData[rowSize - 1, j]; 
                        }
                        
                        for (int i = rowSize - 1; i > 0; --i)
                        {
                            for (int j = 0; j < columnSize; ++j)
                            {
                                temporaryData[i, j] = temporaryData[i - 1, j];
                            }
                        }
                        
                        for (int j = 0; j < columnSize; ++j)
                        {
                            temporaryData[0, j] = temporaryArray[j];
                        }
                        
                        data = temporaryData;

                        break;

                    default:
                        Console.WriteLine("invalid Transform Mode");
                        break;
                }
            
        }
    }
}
