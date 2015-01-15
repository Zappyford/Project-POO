using PetitMonde.Map.Cells;
using PetitMonde.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetitMonde
{
    [Serializable()]
    public class PlayerImpl : Player
    {
        public PlayerImpl(Tribe tribe, int defaultX, int defaultY, int numberOfUnits, String name)
        {
            Tribe = tribe;
            Nickname = name;
            Units = new List<Unit>(numberOfUnits);
            for (int i = 0; i < numberOfUnits; i++)
            {
                Units.Add(Tribe.createUnit(defaultX,defaultY));
            }
        }

        public PetitMonde.Units.Tribe Tribe
        {
            get;
            private set;
        }

        public List<PetitMonde.Units.Unit> Units
        {
            get;
            set;
        }

        public string Nickname
        {
            get;
            private set;
        }

        public void EndTurn()
        {
            GameImpl.INSTANCE.CurrentPlayer = GameImpl.INSTANCE.OpponentPlayer;
            GameImpl.INSTANCE.OpponentPlayer = this;
        }
    
        public void Fight(Unit unit1, Unit unit2)
        {
            unit1.AttackUnit(unit2);
        }


        public List<Unit> GetUnitsOnCell(int x, int y)
        {
            return Units.FindAll(u => u.X == x && u.Y == y && !u.IsDead);
        }

        public Unit GetBestDefensiveUnit(int x, int y)
        {
            return Units.OrderByDescending(u => u.Health).First();
        }

        bool Player.HasLost
        {
            get { return Units.Where(u => !u.IsDead).Count() == 0; }
        }

        public int Score
        {
            get { 
                int bonusPoints = 0;
                foreach (Unit u in Units.Where(u => !u.IsDead))
                    bonusPoints += u.BonusPoints;

                int basePoints = 0;
                IEnumerable<Unit> distinctUnits = Units.Distinct(new UnitsOnSameCellComparer()).Where(u => !u.IsDead); // Sélection des unités sur des cases différentes
                foreach (Unit u in distinctUnits)
                {
                    basePoints += GameImpl.INSTANCE.Map.GetCell(u.X, u.Y).GetScore(Tribe.FactionName);
                }
                return basePoints + bonusPoints;
            }
        }


        public void ClearMovingPoints()
        {
            foreach (Unit u in Units)
            {
                u.clearMovingPoints();
            }
        }


        public void ClearDeadUnits()
        {
            Units = Units.Where(u => !u.IsDead).ToList();
        }
    }

    /// <summary>
    /// Comparer of units by the current coordinates.
    /// Units will be equals if they are on the same cell
    /// </summary>
    class UnitsOnSameCellComparer : EqualityComparer<Unit>
    {
        public override bool Equals(Unit x, Unit y)
        {
            return x.X == y.X && x.Y == y.Y;
        }

        public override int GetHashCode(Unit obj)
        {
            return obj.X * 50 + obj.Y;
        }
    }
}
