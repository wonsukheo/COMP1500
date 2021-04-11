using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment4
{
    public class Arena
    {
        List<Monster> arenaMonsterList = new List<Monster>();

        public uint Capacity { get; private set; }

        public string ArenaName { get; private set; }

        public uint Turns { get; private set; }

        public uint MonsterCount { get; private set; }
        public Arena(string arenaName, uint capacity)
        {
            Capacity = capacity;
            ArenaName = arenaName;
            MonsterCount = 0;
            Turns = 0;
        }

        public void LoadMonsters(string filepath)
        {
            try
            {
                string[] monsterData = new string[Capacity];

                monsterData = File.ReadAllLines(filepath);

                for (int i = 0; i < monsterData.Length; i++)
                {
                    string[] monsterInfo = new string[5];

                    monsterInfo = monsterData[i].Split(',');

                    string monsterName = monsterInfo[0];
                    EElementType monsterElementType = (EElementType)Enum.Parse(typeof(EElementType), monsterInfo[1]);
                    int monsterHealth = int.Parse(monsterInfo[2]);
                    int monsterAttack = int.Parse(monsterInfo[3]);
                    int monsterDefense = int.Parse(monsterInfo[4]);
                    arenaMonsterList.Add(new Monster(monsterName, monsterElementType, monsterHealth, monsterAttack, monsterDefense));

                    MonsterCount++;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine($"file not found: {e.Message}");
            }
        }

        public void GoToNextTurn()
        {
            for (int i = 0; i < MonsterCount; i++)
            {
                if (MonsterCount == 1)
                {
                    break;
                }

                if (i == MonsterCount - 1)
                {
                    arenaMonsterList[i].Attack(arenaMonsterList[0]);

                    if (arenaMonsterList[0].Health == 0)
                    {
                        arenaMonsterList.RemoveAt(0);

                        MonsterCount--;
                    }
                }
                else
                {
                    arenaMonsterList[i].Attack(arenaMonsterList[i + 1]);

                    if (arenaMonsterList[i + 1].Health == 0)
                    {
                        arenaMonsterList.RemoveAt(i + 1);

                        MonsterCount--;
                    }
                }
            }

            Turns++;
        }
        public Monster GetHealthiest()
        {
            if (MonsterCount == 0)
            {
                return null;
            }

            Monster healthiestMonster = arenaMonsterList[0];

            for (int i = 1; i < MonsterCount; i++)
            {
                if (arenaMonsterList[i].Health > healthiestMonster.Health)
                {
                    healthiestMonster = arenaMonsterList[i];
                }
            }

            return healthiestMonster;
        }
    }
}
