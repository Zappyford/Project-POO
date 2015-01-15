using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Units
{
    public interface Tribe
    {
        Faction FactionName
        {
            get;
        }

        Unit createUnit(int defaultX, int defaultY);
    }
}
