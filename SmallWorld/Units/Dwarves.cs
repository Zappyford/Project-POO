using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Units
{
    public class Dwarves : TribeImpl
    {
        public Dwarves()
        {
            FactionName = Faction.Dwarves;
        }

        public Faction FactionName
        {
            get;
            private set;
        }
    }
}
