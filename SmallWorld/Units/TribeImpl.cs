
using System;
namespace PetitMonde.Units
{
    [Serializable()]
    public abstract class TribeImpl : Tribe
    {
  
        public abstract Unit createUnit(int defaultX, int defaultY);

        public abstract Faction FactionName
        {
            get;
        }
    }
}
