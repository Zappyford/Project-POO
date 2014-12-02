using PetitMonde.Units;
using System;

namespace PetitMonde.Map.Cells
{
    public class Plains : CellImpl
    {
        public Plains()
        {
           
        }

        public override float GetMovingCost(Faction faction)
        {
            if (faction == Faction.Orcs || faction == Faction.Dwarves)
            {
                return BaseMovingCost / 2;
            }
            else
            {
                return BaseMovingCost;
            }
        }

        public override int GetScore(Faction faction)
        {
            if (faction == Faction.Dwarves)
                return 0;
            else
                return BaseScore;
        }

        public override CellType getType()
        {
            return CellType.Plains;
        }
    }
}
