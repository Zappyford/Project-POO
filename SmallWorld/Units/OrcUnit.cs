﻿
namespace PetitMonde.Units
{
    public class OrcUnit : PetitMonde.Units.UnitImpl
    {
        public OrcUnit(int defaultX, int DefaultY)
            : base(defaultX, DefaultY)
        {
            Faction = PetitMonde.Faction.Orcs;
        }
    
        public override int BonusPoints
        {
            // Orcs get bonus point for each unit killed, only if the killer unit is not dead
            get
            {
                if (!IsDead)
                    return UnitsKilled;
                else
                    return 0;
            }
        }
    }
}
