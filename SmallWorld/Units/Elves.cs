using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Units
{
    public class Elves : TribeImpl
    {
        public Elves()
        {
            FactionName = Faction.Elves;
        }

        public Faction FactionName
        {
            get;
            private set;
        }
    }
}
