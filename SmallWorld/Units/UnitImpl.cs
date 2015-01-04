using PetitMonde.Map.Cells;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PetitMonde.Units
{
    [Serializable()]
    public abstract class UnitImpl : Unit
    {
        private static Random rand = new Random();


        /// <summary>
        /// Health points by default
        /// </summary>
        public int DEFAULT_HEALTH
        {
            get { return 5; }
        }

        /// <summary>
        /// Attack points by default 
        /// </summary>
        public int DEFAULT_ATTACK
        {
            get { return 2; }
        }


        /// <summary>
        /// Defense points by default
        /// </summary>
        public int DEFAULT_DEFENSE
        {
            get { return 1; }
        }

        /// <summary>
        /// Moving points by default
        /// </summary>
        public int DEFAULT_MOVING_POINTS
        {
            get { return 1; }
        }


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

        private int XField;
        public int X
        {
            get
            {
                return XField;
            }
            protected set
            {
                XField = value;
                OnPropertyChanged();
            }
        }

        private int YField;
        public int Y
        {
            get
            {
                return YField;
            }
            protected set
            {
                YField = value;
                OnPropertyChanged();
            }
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
            int numberOfAttacks = rand.Next(3, Math.Max(this.Health, unit.Health)+2);
            while (numberOfAttacks > 0 && !IsDead && !unit.IsDead)
            {
                int AttackingUnitAttack = (int)Math.Round(this.Attack * (this.Health / (double)DEFAULT_HEALTH), 0, MidpointRounding.AwayFromZero);
                int AttackedUnitDefense = (int)Math.Round(unit.Defense * (unit.Health / (double)DEFAULT_HEALTH), 0, MidpointRounding.AwayFromZero);
                double chanceOfAttackingUnitWin;

                if (AttackingUnitAttack >= AttackedUnitDefense)
                    chanceOfAttackingUnitWin = 0.5d + 0.5d * (1d - ((double)AttackedUnitDefense / AttackingUnitAttack));
                else
                    chanceOfAttackingUnitWin = 1d - (0.5d + 0.5d * (1d - ((double)AttackingUnitAttack / AttackedUnitDefense)));

                if (rand.NextDouble() < chanceOfAttackingUnitWin)
                {
                    // The attacking unit wins this attack
                    unit.Health--;
                }
                else
                {
                    this.Health--;
                }
                numberOfAttacks--;
            }

            if (this.IsDead)
                ((UnitImpl)unit).UnitsKilled++;
            else if (unit.IsDead)
                this.UnitsKilled++;


        }



        public void clearMovingPoints()
        {
            this.MovingPoints = DEFAULT_MOVING_POINTS;
        }

        #region INotifyPropertyChanged

        [field: NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

 
    }
}
