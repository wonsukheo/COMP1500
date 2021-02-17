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
                for(int j = 0; j < width + 4; ++j)
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

                    uint leftcount = 2;
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
                            if ((center - i)*(center - i) + (center - j)*(center - j) <= radius * radius)
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
            EShape canvasShape;
            if (canvas[2,2] == '*' && canvas[3,2] == '*')
            {
                if (canvas[2, 3] == '*' && canvas[3, 3] == '*')
                {
                    canvasShape = EShape.Rectangle;
                }
                canvasShape = EShape.IsoscelesRightTriangle;
            }
            else
            {
                if (canvas.GetLength(0) == canvas.GetLength(1))
                {
                    canvasShape = EShape.Circle;
                }
                canvasShape = EShape.IsoscelesTriangle;
            }

            return canvasShape == shape ? true : false;
        }
    }
}
