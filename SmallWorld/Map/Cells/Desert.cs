﻿using System;

namespace PetitMonde.Map.Cells
{
    public class Desert : CellImpl
    {
        public Desert()
        {
           
        }


        public override float GetMovingCost(Faction faction)
        {
            throw new NotImplementedException();
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
