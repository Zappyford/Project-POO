using PetitMonde.Units;
using System;

namespace PetitMonde.Map.Cells
{
    public class Forest : CellImpl
    {
        public Forest()
        {
           
        }


        public override float GetMovingCost(Faction faction)
        {
            if (faction == Faction.Elves)
                return BaseMovingCost / 2;

            else
                return BaseMovingCost;
        }

        public override int GetScore(Faction faction)
        {
            if (faction == Faction.Orcs)
                return 0;
            else
                return BaseScore;
        }

        public override CellType getType()
        {
            return CellType.Forest;
        }
    }
}
