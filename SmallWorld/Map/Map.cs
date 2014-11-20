using PetitMonde.Map.Cells;

namespace PetitMonde.Map
{
    public interface Map
    {

        Cell GetCell(int x, int y);

        bool CellIsAdjacentTo(int x, int y, int xTarget, int yTarget);

    }
}
