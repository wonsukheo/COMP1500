using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
    public static class Lab8
    {
        public static string PrettifyList(string s)
        {
            // check pre-conditions
            if (String.IsNullOrWhiteSpace(s) || s.Length == 0)
            {
                return null;
            }

            StringBuilder prettifyString = new StringBuilder(4096);

            string[] firstLevel = s.Split('|'); 

            int firstLevelLabel = 1;

            for (int i = 0; i < firstLevel.Length; i++)
            {
                if (firstLevel[i] != null)
                {
                    prettifyString.Append($"{firstLevelLabel}) ");


                    prettifyString.Append(firstLevel[i]);

                    string secondLevelLable = "abcdefghijklmnopqrstuvwxyz";
                    int secondLevelCount = 0;

                    int j = 0;
                    for (; j < prettifyString.Length; j++)
                    {
                        if (firstLevelLabel != 1 && prettifyString[j] == '_')
                        {
                            prettifyString.Replace("_", $"\n    {secondLevelLable[secondLevelCount % secondLevelLable.Length]}) ", j, 1);

                            for (int k = 0; k < secondLevelCount / secondLevelLable.Length; k++)
                            {
                                prettifyString.Insert(j + 5, $"{secondLevelLable[secondLevelCount % secondLevelLable.Length]}");
                            }

                            secondLevelCount++;
                        }

                        if (secondLevelCount != 0 && prettifyString[j] == '/')
                        {
                            prettifyString.Replace("/", "\n        - ", j, 1);
                        }
                    }
                    firstLevelLabel++;
                    prettifyString.AppendLine();
                }
            }
            
            return prettifyString.ToString();
        }
    }
}
