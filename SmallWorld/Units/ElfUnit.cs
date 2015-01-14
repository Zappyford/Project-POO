using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde
{
    [Serializable()]
    public class ElfUnit : PetitMonde.Units.UnitImpl
    {
        public ElfUnit(int defaultX, int DefaultY)
            : base(defaultX, DefaultY)
        {
            Faction = Units.Faction.Elves;
        }

        public override float ChanceOfRetreat
        {
            get { return .5f; }
        }
    }
}
