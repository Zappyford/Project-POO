
namespace PetitMonde.Units
{
    public class OrcUnit : PetitMonde.Units.UnitImpl
    {
        public override int GetBonusPoints()
        {
            if (!IsDead())
                return UnitsKilled;
            else
                return 0;
        }
    }
}
