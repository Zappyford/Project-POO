
namespace PetitMonde.Map.Cells
{
    public abstract class CellImpl : Cell
    {
        public abstract float GetMovingCost(Faction faction);

        public abstract int GetScore(Faction faction);
    }
}
