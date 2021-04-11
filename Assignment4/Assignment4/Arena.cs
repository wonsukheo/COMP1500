using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment4
{
    public class Arena
    {
        public uint Capacity { get; private set; }

        public string ArenaName { get; private set; }

        public uint Turns { get; private set; }

        public uint MonsterCount { get; private set; }

        private List<Monster> mArenaMonsterList = new List<Monster>();
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

                for (int i = 0; i < Capacity; i++)
                {
                    string[] monsterInfo = new string[5];

                    monsterInfo = monsterData[i].Split(',');

                    string monsterName = monsterInfo[0];
                    EElementType monsterElementType = (EElementType)Enum.Parse(typeof(EElementType), monsterInfo[1]);
                    int monsterHealth = int.Parse(monsterInfo[2]);
                    int monsterAttack = int.Parse(monsterInfo[3]);
                    int monsterDefense = int.Parse(monsterInfo[4]);
                    mArenaMonsterList.Add(new Monster(monsterName, monsterElementType, monsterHealth, monsterAttack, monsterDefense));

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
            if (MonsterCount > 1)
            {
                for (int i = 0; i < MonsterCount; i++)
                {
                    if (i == MonsterCount - 1)
                    {
                        mArenaMonsterList[i].Attack(mArenaMonsterList[0]);

                        if (mArenaMonsterList[0].Health == 0)
                        {
                            mArenaMonsterList.RemoveAt(0);

                            MonsterCount--;
                        }
                    }
                    else
                    {
                        mArenaMonsterList[i].Attack(mArenaMonsterList[i + 1]);

                        if (mArenaMonsterList[i + 1].Health == 0)
                        {
                            mArenaMonsterList.RemoveAt(i + 1);

                            MonsterCount--;
                        }
                    }
                }

                Turns++;
            }
        }
        public Monster GetHealthiest()
        {
            if (MonsterCount == 0)
            {
                return null;
            }

            Monster healthiestMonster = mArenaMonsterList[0];

            for (int i = 1; i < MonsterCount; i++)
            {
                if (mArenaMonsterList[i].Health > healthiestMonster.Health)
                {
                    healthiestMonster = mArenaMonsterList[i];
                }
            }

            return healthiestMonster;
        }
    }
}
