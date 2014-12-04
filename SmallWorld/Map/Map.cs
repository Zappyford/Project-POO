using PetitMonde.Map.Cells;

namespace PetitMonde.Map
{
    public interface Map
    {
        /// <summary>
        /// Stores the cells in an array
        /// </summary>
        PetitMonde.Map.Cells.Cell[] mapCells
        {
            get;
            set;
        }

        /// <summary>
        /// The size of the map
        /// </summary>
        int Size
        {
            get;
        }

        /// <summary>
        /// Gets cell at the given coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>The cell at the given coordinates</returns>
        Cell GetCell(int x, int y);

        /// <summary>
        /// Check if the cell and the targeted cell are adjacent
        /// </summary>
        /// <param name="x">x Coordinate</param>
        /// <param name="y">y Coordinate</param>
        /// <param name="xTarget">x Coordinate (targeted cell)</param>
        /// <param name="yTarget">y Coordinate (targeted cell)</param>
        /// <returns>True if the cells are adjacent</returns>
        bool CellIsAdjacentTo(int x, int y, int xTarget, int yTarget);

        /// <summary>
        /// Gets the index in the tab of cells from the given coordinates
        /// </summary>
        /// <param name="x">x Coordinate</param>
        /// <param name="y">y Coordinate</param>
        /// <returns>The index</returns>
        int getIndexFromCoodinates(int x, int y);

    }
}
