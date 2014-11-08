using PetitMonde.Map.Cells;
using System;

namespace PetitMonde
{
    public class PlayerImpl : Player
    {
        public PlayerImpl(Faction faction, int defaultX, int defaultY, int numberOfUnits)
        {
            throw new System.NotImplementedException();
        }

        public PetitMonde.Units.TribeImpl Tribe
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public System.Collections.Generic.List<PetitMonde.Units.UnitImpl> Units
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Name
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void AttackUnit(Unit unit, Cell dest)
        {
            throw new NotImplementedException();
        }

        public void EndTurn()
        {
            throw new NotImplementedException();
        }

        public void Fight(Unit unit1, Unit unit2)
        {
            throw new NotImplementedException();
        }

        public void MoveUnit(Unit unit, int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool HasLost()
        {
            throw new NotImplementedException();
        }


        public int GetScore()
        {
            throw new NotImplementedException();
        }


        public bool HasUnitsOnCell(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Unit GetBestDefensiveUnit(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
