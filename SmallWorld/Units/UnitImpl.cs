﻿using PetitMonde.Map.Cells;
using System;
using System.Collections.Generic;
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
        public int DefaultHealth
        {
            get { return 5; }
        }

        /// <summary>
        /// Attack points by default 
        /// </summary>
        public int DefaultAttack
        {
            get { return 2; }
        }


        /// <summary>
        /// Defense points by default
        /// </summary>
        public int DefaultDefense
        {
            get { return 1; }
        }

        /// <summary>
        /// Moving points by default
        /// </summary>
        public double DefaultMovingPoints
        {
            get { return 1; }
        }


        public UnitImpl(int defaultX, int defaultY)
        {
            Attack = DefaultAttack;
            Health = DefaultHealth;
            Defense = DefaultDefense;
            MovingPoints = DefaultMovingPoints;
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

        private int HealthField;
        public int Health
        {
            get
            {
                return HealthField;
            }
            set
            {
                if (value >= 0)
                {
                    HealthField = value;
                }
                else
                {
                    HealthField = 0;
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

        private double MovingPointsField;
        public double MovingPoints
        {
            get
            {
                return MovingPointsField;
            }
            set
            {
                if (value < 0)
                    MovingPointsField = 0;
                else
                    MovingPointsField = value;

                OnPropertyChanged();
            }
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

        public CombatReport AttackUnit(Unit unit)
        {
            CombatReport cr = new CombatReport(this, unit);

            int numberOfAttacks = rand.Next(3, Math.Max(this.Health, unit.Health)+2);
            while (numberOfAttacks > 0 && !IsDead && !unit.IsDead)
            {
                int AttackingUnitAttack = (int)Math.Round(this.Attack * (this.Health / (double)DefaultHealth), 0, MidpointRounding.AwayFromZero);
                int AttackedUnitDefense = (int)Math.Round(unit.Defense * (unit.Health / (double)DefaultHealth), 0, MidpointRounding.AwayFromZero);
                double chanceOfAttackingUnitWin;

                if (AttackingUnitAttack >= AttackedUnitDefense)
                    chanceOfAttackingUnitWin = 0.5d + 0.5d * (1d - ((double)AttackedUnitDefense / AttackingUnitAttack));
                else
                    chanceOfAttackingUnitWin = 1d - (0.5d + 0.5d * (1d - ((double)AttackingUnitAttack / AttackedUnitDefense)));

                if (rand.NextDouble() < chanceOfAttackingUnitWin)
                {
                    // The attacking unit wins this attack
                    unit.Health--;
                    cr.DefensingUnitLostHealth--;
                }
                else
                {
                    this.Health--;
                    cr.AttackingUnitLostHealth--;
                }
                numberOfAttacks--;
            }

            if (this.IsDead)
            {
                if (rand.NextDouble() <= this.ChanceOfRetreat)
                {
                    this.Health = 1;
                    cr.AttackingUnitRetreat = true;
                }
                else
                {
                    ((UnitImpl)unit).UnitsKilled++;
                }
            }
            else if (unit.IsDead)
            {
                if (rand.NextDouble() <= unit.ChanceOfRetreat)
                {
                    unit.Health = 1;
                    cr.DefensingUnitRetreat = true;
                }
                else
                {
                    this.UnitsKilled++;
                }
            }
            return cr;
        }



        public void clearMovingPoints()
        {
            this.MovingPoints = DefaultMovingPoints;
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




        public abstract float ChanceOfRetreat
        {
            get;
        }
    }
}
