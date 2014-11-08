
namespace PetitMonde.Map.Cells
{
    public interface Cell
    {

        public abstract float GetMovingCost(Faction faction);

        int GetScore(Faction faction);

    }


}
