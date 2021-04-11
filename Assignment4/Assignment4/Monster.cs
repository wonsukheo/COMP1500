
namespace Assignment4
{
    public class Monster
    {
        public string Name { get; private set; }
        public EElementType ElementType { get; private set; }
        
        private int mHealth;
        public int Health
        {
            get
            {
                return mHealth;
            }
            private set
            {
                mHealth = value;

                if (mHealth < 0)
                {
                    mHealth = 0;
                }
            }
        }

        private int mAttackStat;
        public int AttackStat
        {
            get
            {
                return mAttackStat;
            }
            private set
            {
                if (AttackStat < 0)
                {
                    AttackStat = 0;
                }
            }
        }

        private int mDefenseStat;
        public int DefenseStat
        {
            get
            {
                return mDefenseStat;
            }
            private set
            {
                DefenseStat = mDefenseStat;

                if (mDefenseStat < 0)
                {
                    mDefenseStat = 0;
                }
            }
        }

        public Monster(string name, EElementType elementType, int health, int attack, int defense)
        {
            //health, attack, defense arg is always uint
            Name = name;
            ElementType = elementType;
            mHealth = health;
            mAttackStat = attack;
            mDefenseStat = defense;
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
        }

        public void Attack(Monster otherMonster)
        {
            int normalDamage = mAttackStat - otherMonster.DefenseStat;

            int totalDamage = normalDamage;

            if (ElementType == EElementType.Fire)
            {
                if (otherMonster.ElementType == EElementType.Wind)
                {
                    totalDamage = (int)(normalDamage * 1.5);
                }
                else if (otherMonster.ElementType == EElementType.Water || otherMonster.ElementType == EElementType.Earth)
                {
                    totalDamage = normalDamage / 2;
                }
            }
            else if (ElementType == EElementType.Wind)
            {
                if (otherMonster.ElementType == EElementType.Water || otherMonster.ElementType == EElementType.Earth)
                {
                    totalDamage = (int)(normalDamage * 1.5);
                }
                else if (otherMonster.ElementType == EElementType.Fire)
                {
                    totalDamage = normalDamage / 2;
                }
            }
            else
            {
                if (otherMonster.ElementType == EElementType.Fire)
                { 
                    totalDamage = (int)(normalDamage * 1.5);
                }
                else if (otherMonster.ElementType == EElementType.Wind)
                {
                    totalDamage = normalDamage / 2;
                }
            }

            if (totalDamage < 0)
            {
                totalDamage = 1;
            }

            otherMonster.Health -= totalDamage;
        }
    }
}
