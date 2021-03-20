using System.Collections.Generic;

namespace Lab9
{
    class Lab9
    {
        public static List<int> MergeLists(List<int> sortedList1, List<int> sortedList2)
        {
            List<int> mergedList = new List<int>(sortedList1.Count + sortedList2.Count);

            int i = 0;
            int j = 0;

            while (i < sortedList1.Count)
            {
                while (j < sortedList2.Count)
                {
                    if (sortedList2[j] >= sortedList1[i])
                    {
                        mergedList.Add(sortedList1[i]);
                        i++;
                        break;
                    }
                    else
                    {
                        mergedList.Add(sortedList2[j]);
                        j++;
                    }
                }
                if (j == sortedList2.Count)
                {
                    mergedList.Add(sortedList1[i]);
                    i++;
                }
            }
            
            if (j < sortedList2.Count)
            {
                for (; j < sortedList2.Count; j++)
                {
                    mergedList.Add(sortedList2[j]);
                }
            }

            return mergedList;
        }

        public static Dictionary<string, int> CombineListsToDictionary(List<string> keys, List<int> values)
        {
            int combinedCapacity = keys.Count > values.Count ? values.Count : keys.Count;
            Dictionary<string, int> combinedDictionary = new Dictionary<string, int>(combinedCapacity);

            for (int i = 0; i < keys.Count; i++)
            {
                combinedDictionary.TryAdd(keys[i], values[i]);
                if (combinedDictionary.Count == combinedCapacity)
                {
                    break;
                }
            }

            /*foreach (KeyValuePair<string, int> dictionary in combinedDictionary)
            {
                Console.WriteLine($"Key: {dictionary.Key} // Value: {dictionary.Value}");
            }*/
            return combinedDictionary;
        }

        public static Dictionary<string, decimal> MergeDictionaries(Dictionary<string, int> numerators, Dictionary<string, int> denominators)
        {
            Dictionary<string, decimal> mergedDictionary = new Dictionary<string, decimal>();

            if (numerators.Count == 0 || denominators.Count == 0)
            {
                return mergedDictionary;
            }

            foreach (KeyValuePair<string, int> numerator in numerators)
            {
                int value;

                if (denominators.TryGetValue(numerator.Key, out value))
                {
                    if (value != 0)
                    {
                        decimal result = numerator.Value / (decimal)value;
                        if (result < 0)
                        {
                            result *= -1;
                        }    
                        mergedDictionary.Add(numerator.Key, result);
                    }
                }
            }

            return mergedDictionary;
        }
    }
}
