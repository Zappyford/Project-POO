using PetitMonde.Units;
using System;

namespace PetitMonde.Map.Cells

{
    [Serializable()]
    public class Desert : CellImpl
    {
        public Desert()
        {
           
        }

        public override float GetMovingCost(Faction faction)
        {
            if (faction == Faction.Elves)
                return BaseMovingCost * 2;

            else
                return BaseMovingCost;
        }

        public override int GetScore(Faction faction)
        {
            throw new NotImplementedException();
        }

        public override CellType getType()
        {
            return CellType.Desert;
        }
        
    }
}
