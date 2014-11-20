
namespace PetitMonde.Map.Cells
{
    public abstract class CellImpl : Cell
    {
        protected const float BaseMovingCost = 1;
        protected const int BaseScore = 1;

        public abstract float GetMovingCost(Faction faction);

        public abstract int GetScore(Faction faction);

        public abstract CellType getType();
    }
}
