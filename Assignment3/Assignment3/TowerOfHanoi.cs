using System.Collections.Generic;
using System;

namespace Assignment3
{
    class TowerOfHanoi
    {
        public static int GetNumberOfSteps(int numDiscs)
        {
            if (numDiscs < 1)
            {
                return -1;
            }    
            else if (numDiscs == 1)
            {
                return 1;
            }
            return GetNumberOfSteps(numDiscs - 1) * 2 + 1;
        }
        public static List<List<int>[]> SolveTowerOfHanoi(int numDiscs)
        {
            int timetotal = GetNumberOfSteps(numDiscs);
            
            List<int> firstStep = new List<int>(numDiscs);
            List<int>[] secondStep = new List<int>[3];
            List<List<int>[]> thirdStep = new List<List<int>[]>(timetotal);

            for (int i = numDiscs; i != 0; i--)
            {
                firstStep.Add(i);
            }
            secondStep[0] = firstStep;

            for (int i = 1; i < 3; i++)
            {
                secondStep[i] = new List<int>(0);
            }

            thirdStep.Add(secondStep);

            thirdStep = MoveDiscs(numDiscs, 0, 2 ,1, thirdStep);

            return thirdStep;
        }

        public static List<List<int>[]> MoveDiscs(int numDiscs, int source, int dest, int temp, List<List<int>[]> listByStep)
        {
            if (numDiscs > 1)
            {
                MoveDiscs(numDiscs - 1, source, temp, dest, listByStep);
            }
            //move source to dest

            List<int>[] secondStep = new List<int>[3] { new List<int>(), new List<int>(), new List<int>()};
            List<int> firstStep = new List<int>(numDiscs);
            
            for (int i = 0; i < 3; i++)
            {
                foreach (var listElement in listByStep[listByStep.Count - 1][i])
                {
                    secondStep[i].Add(listElement);
                }
            }

            secondStep[source].Remove(numDiscs);
            secondStep[dest].Add(numDiscs);
            listByStep.Add(secondStep);

            if (numDiscs > 1)
            {
                MoveDiscs(numDiscs - 1, temp, dest, source, listByStep);
            }
            return listByStep;
        }
    }
}
