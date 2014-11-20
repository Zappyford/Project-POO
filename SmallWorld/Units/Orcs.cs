using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Units
{
    public class Orcs : TribeImpl
    {
        public Orcs()
        {
            FactionName = Faction.Orcs;
        }

        public Faction FactionName
        {
            get;
            private set;
        }
    }
}
