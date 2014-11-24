using PetitMonde.Map.Cells;

namespace PetitMonde.Map
{
    public interface Map
    {

        PetitMonde.Map.Cells.CellImpl[] mapCells
        {
            get;
            set;
        }

        Cell GetCell(int x, int y);

        bool CellIsAdjacentTo(int x, int y, int xTarget, int yTarget);

    }
}
