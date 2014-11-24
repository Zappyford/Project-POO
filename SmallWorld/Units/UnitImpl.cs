using PetitMonde.Map.Cells;
using System;

namespace PetitMonde.Units
{
    public abstract class UnitImpl : Unit
    {
        /// <summary>
        /// Health points by default
        /// </summary>
        private const int DEFAULT_HEALTH = 5;

        /// <summary>
        /// Attack points by default 
        /// </summary>
        private const int DEFAULT_ATTACK = 2;

        /// <summary>
        /// Defense points by default
        /// </summary>
        private const int DEFAULT_DEFENSE = 1;

        /// <summary>
        /// Moving points by default
        /// </summary>
        private const int DEFAULT_MOVING_POINTS = 1;

        public UnitImpl(int defaultX, int defaultY)
        {
            Attack = DEFAULT_ATTACK;
            Health = DEFAULT_HEALTH;
            Defense = DEFAULT_DEFENSE;
            MovingPoints = DEFAULT_MOVING_POINTS;
            X = defaultX;
            Y = defaultY;
        }

        public int Attack
        {
            get;
            set;
        }

        public int Defense
        {
            get;
            set;
        }

        private int _health;
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                if (value >= 0)
                {
                    _health = value;
                }
                else
                {
                    _health = 0;
                }
            }
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public float MovingPoints
        {
            get;
            set;
        }


        public Faction Faction
        {
            get;
            set;
        }

        /// <summary>
        /// Number of units killeds by this unit
        /// Used to calculate bonus points
        /// </summary>
        protected int UnitsKilled = 0;



        public bool Move(int x, int y)
        {
            if (CanMove(x, y))
            {
                X = x;
                Y = y;
                MovingPoints -= GameImpl.INSTANCE.Map.GetCell(x, y).GetMovingCost(Faction);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean IsDead
        {
            get
            {
                return Health == 0;
            }
        }


        public virtual int BonusPoints
        {
            get
            {
                return 0;
            }
        }

        public void Die()
        {
            Health = 0;
        }

        public virtual bool CanMove(int x, int y)
        {
            Cell cell =  GameImpl.INSTANCE.Map.GetCell(x, y);
            return cell.GetMovingCost(this.Faction) <= MovingPoints && GameImpl.INSTANCE.Map.CellIsAdjacentTo(X,Y,x,y);
        }

        public void AttackUnit(Unit unit)
        {
            throw new NotImplementedException();
        }

    }
}
