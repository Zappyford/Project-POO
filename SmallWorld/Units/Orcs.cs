using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Units

{
    [Serializable()]
    public class Orcs : TribeImpl
    {
        public Orcs()
        {
            
        }

        public override Faction FactionName
        {
            get { return Faction.Orcs; }
        }

        public override Unit createUnit(int defaultX, int defaultY)
        {
            return new OrcUnit(defaultX, defaultY);
        }
    }
}
