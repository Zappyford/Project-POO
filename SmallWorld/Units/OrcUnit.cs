
namespace PetitMonde.Units
{
    public class OrcUnit : PetitMonde.Units.UnitImpl
    {
        public OrcUnit(int defaultX, int DefaultY)
            : base(defaultX, DefaultY)
        {
            Faction = PetitMonde.Faction.Orcs;
        }
    
        public override int GetBonusPoints()
        {
            if (!IsDead())
                return UnitsKilled;
            else
                return 0;
        }
    }
}
