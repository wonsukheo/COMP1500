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
            if (s == null || s.Length == 0)
            {
                return null;
            }
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] != ' ')
                {
                    break;
                }
                
                if (i == s.Length - 1)
                {
                    return null;
                }
            }

            StringBuilder newString = new StringBuilder(4096);

            string[] firstLevel = s.Split('|');

            char firstLevelChar = '1';

            for (int i = 0; i < firstLevel.Length; i++)
            {
                if (firstLevel[i] != null)
                {
                    //char secondLevelChar = 'a';
                    newString.Append($"{firstLevelChar}) ");  //newString.Insert(0, $"{firstLevelChar}) ");
                    firstLevelChar++;

                    newString.Append(firstLevel[i]);   // what if arg is null. exception throw?

                    char secondLevelChar = 'a';
                    char secondLevelCharDouble = 'a';
                    char secondLevelCharTripple = 'a';

                    int j = 0;
                    for (; j < newString.Length; j++)
                    {
                        if (firstLevelChar != 1 && newString[j] == '_')
                        {
                            if (secondLevelChar > 'z')
                            {
                                newString.Replace("_", $"\n    {secondLevelCharDouble}{secondLevelCharDouble}) ", j, 1);
                                secondLevelCharDouble++;
                            }
                            if (secondLevelCharDouble > 'z')
                            {
                                newString.Replace("_", $"\n    {secondLevelCharTripple}{secondLevelCharTripple}{secondLevelCharTripple}) ", j, 1);
                                secondLevelCharTripple++;
                            }

                            newString.Replace("_", $"\n    {secondLevelChar}) ", j, 1);
                            secondLevelChar++;
                        }

                        if (secondLevelChar != 'a' && newString[j] == '/')
                        {
                            newString.Replace("/", $"\n\t- ", j, 1);
                        }
                    }
                    newString.AppendLine();
                }
            }
            
            return newString.ToString();
        }
    }
}
