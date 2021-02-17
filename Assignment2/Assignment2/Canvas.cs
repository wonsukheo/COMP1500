using System.Diagnostics;

namespace Assignment2
{
    public static class Canvas
    { 
        public static char[,] Draw(uint width, uint height, EShape shape)
        {
            char[,] invalidFormat = new char[0, 0];
            char[,] canvas = new char[height + 4, width + 4];

            if (width == 0 || height == 0)
            {
                return invalidFormat;
            }
                    
            #region draw_outline
            for (int i = 0; i < height + 4; ++i)
            {
                for (int j = 0; j < width + 4; ++j)
                {
                    if (i == 0 || i == height + 3)
                    {
                        canvas[i, j] = '-';
                    } 
                    else
                    {
                        if (j == 0 || j == width + 3)
                        {
                            canvas[i, j] = '|';
                        }
                        else
                        {
                            canvas[i, j] = ' ';
                        }
                    }
                }
            }
            #endregion

            switch ((int)shape)
            {
                case 0:
                    for (int i = 2; i < height + 2; ++i)
                    {
                        for (int j = 2; j < width + 2; ++j)
                        {
                            canvas[i, j] = '*';
                        }
                    }
                    break;
                case 1:
                    if (height != width)
                    {
                        return invalidFormat;
                    }
                    for (int i = 2; i < height + 2; ++i)
                    {
                        for (int j = 2; j < i + 1; ++j)
                        {
                            canvas[i, j] = '*';
                        }
                    }
                    break;
                case 2:
                    if (height * 2 - 1 != width)
                    {
                        return invalidFormat;
                    }

                    uint leftcount = 2u;
                    uint rightcount = width + leftcount;
                    for (uint i = height + 1; i > 1; --i)
                    {
                        for (uint j = leftcount; j < rightcount; j++)
                        {
                            canvas[i, j] = '*';
                        }
                        leftcount++;
                        rightcount--;
                    }
                    break;
                case 3:
                    if (height != width || width % 2 == 0)
                    {
                        return invalidFormat;
                    }
                    uint diameter = width;
                    uint radius = diameter / 2;
                    uint center = 2 + radius;
                    for (int i = 2; i < height + 2; ++i)
                    {
                        for (int j = 2; j < width + 2; ++j)
                        {
                            if ((center - i) * (center - i) + (center - j) * (center - j) <= radius * radius)
                            {
                                canvas[i, j] = '*';
                            }
                        }
                    }
                    break;
                default:
                    Debug.Assert((int)shape <= 4, "Wrong Shape!");
                    break;
            }

            return canvas;
        }

        public static bool IsShape(char[,] canvas, EShape shape)
        {
            int rowLength = canvas.GetLength(0);
            int colLength = canvas.GetLength(1);
            int width = colLength - 4;
            int height = rowLength - 4;
            
            if (width <= 0 || height <= 0)
            {
                return false;
            }

            int dotCount1 = 0;
            int dotCount2 = 0;

            for (int i = 2; i < 2 + width; ++i)
            {
                if (canvas[height + 1, i] == '*')
                {
                    dotCount1++;
                }
                if (canvas[height, i] == '*')
                {
                    dotCount2++;
                }
            }
            
            EShape canvasShape = EShape.Circle;

            if (dotCount1 == dotCount2 || height == 1)
            {
                canvasShape = EShape.Rectangle;
            } 
            else if (dotCount1 - dotCount2 == 1 && width == height)
            {
                canvasShape = EShape.IsoscelesRightTriangle;
            }
            else if (dotCount1 - dotCount2 == 2 && width == height * 2 - 1)
            {
                canvasShape = EShape.IsoscelesTriangle;
            }

            return (canvasShape == shape) ? true : false;
        }
    }
}
