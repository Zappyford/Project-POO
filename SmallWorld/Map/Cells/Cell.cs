
namespace PetitMonde.Map.Cells
{
    public interface Cell
    {

        float GetMovingCost(Faction faction);

        int GetScore(Faction faction);

        CellType getType();
    }


}
