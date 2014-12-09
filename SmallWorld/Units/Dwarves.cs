using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Units
{
    [Serializable()]
    public class Dwarves : TribeImpl
    {
        public Dwarves()
        {
        }

        public override Faction FactionName
        {
            get { return Faction.Dwarves; }
        }

        public override Unit createUnit(int defaultX, int defaultY)
        {
            return new DwarfUnit(defaultX, defaultY);
        }
    }
}
