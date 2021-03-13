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

            char firstLevelLabel = '1';

            for (int i = 0; i < firstLevel.Length; i++)
            {
                if (firstLevel[i] != null)
                {
                    prettifyString.Append($"{firstLevelLabel}) ");
                    firstLevelLabel++;

                    prettifyString.Append(firstLevel[i]);

                    char secondLevelLable = 'a';
                    char secondLevelCharDouble = 'a';
                    char secondLevelCharTripple = 'a';

                    int j = 0;
                    for (; j < prettifyString.Length; j++)
                    {
                        if (firstLevelLabel != 1 && prettifyString[j] == '_')
                        {
                            if (secondLevelLable > 'z')
                            {
                                prettifyString.Replace("_", $"\n    {secondLevelCharDouble}{secondLevelCharDouble}) ", j, 1);
                                secondLevelCharDouble++;
                            }
                            if (secondLevelCharDouble > 'z')
                            {
                                prettifyString.Replace("_", $"\n    {secondLevelCharTripple}{secondLevelCharTripple}{secondLevelCharTripple}) ", j, 1);
                                secondLevelCharTripple++;
                            }

                            prettifyString.Replace("_", $"\n    {secondLevelLable}) ", j, 1);
                            secondLevelLable++;
                        }

                        if (secondLevelLable != 'a' && prettifyString[j] == '/')
                        {
                            prettifyString.Replace("/", $"\n        - ", j, 1);
                            //prettifyString.Replace("/", $"\n\t- ", j, 1);
                        }
                    }
                    prettifyString.AppendLine();
                }
            }
            
            return prettifyString.ToString();
        }
    }
}
