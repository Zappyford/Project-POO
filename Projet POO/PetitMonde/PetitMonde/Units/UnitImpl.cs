using System;

namespace PetitMonde.Units
{
    public abstract class UnitImpl : Unit
    {
        private const int DEFAULT_HEALTH = 5;
        private const int DEFAULT_ATTACK = 2;
        private const int DEFAULT_DEFENSE = 1;
        private const int DEFAULT_MOVING_POINTS = 1;

        public UnitImpl(int defaultX, int defaultY)
        {
            throw new System.NotImplementedException();
        }

        public int Attack
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Defense
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Health
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int X
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Y
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int MovingPoints
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int UnitsKilled
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Faction Faction
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public bool Move(int x, int y)
        {
            throw new NotImplementedException();
        }


        public void Die()
        {
            throw new NotImplementedException();
        }

        public bool IsDead()
        {
            throw new NotImplementedException();
        }

        public bool CanMove(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void AttackUnit(Unit unit)
        {
            throw new NotImplementedException();
        }


        public int GetBonusPoints()
        {
            return 0;
        }
    }
}
