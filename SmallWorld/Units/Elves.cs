using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Units
{
    [Serializable()]
    public class Elves : TribeImpl
    {
        public Elves()
        {
           
        }

        public override Faction FactionName
        {
            get { return Faction.Elves; }
        }


        public override Unit createUnit(int defaultX, int defaultY)
        {
            return new ElfUnit(defaultX, defaultY);
        }
    }
}
