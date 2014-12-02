using PetitMonde.Units;
using System;

namespace PetitMonde.Map.Cells
{
    public class Mountain : CellImpl
    {
        public Mountain()
        {
            
        }


        public override float GetMovingCost(Faction faction)
        {
            return BaseMovingCost;
        }

        public override int GetScore(Faction faction)
        {
            return 1;
        }

        public override CellType getType()
        {
            return CellType.Mountain;
        }
    }
}
