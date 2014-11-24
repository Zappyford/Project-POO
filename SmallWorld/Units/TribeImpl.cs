
namespace PetitMonde.Units
{
    public abstract class TribeImpl : Tribe
    {
        public abstract Faction FactionName;

        public abstract Unit createUnit(int defaultX, int defaultY);
    }
}
