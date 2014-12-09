using PetitMonde.Map.Cells;
using System;

namespace PetitMonde.Map
{
    [Serializable()]
    public class MapImpl : Map
    {
        

        /// <summary>
        /// The size of the map
        /// </summary>
        private int size;

        public MapImpl(int size)
        {
            this.size = size;
           
        }

        public PetitMonde.Map.Cells.Cell[] mapCells
        {
            get;
            set;
        }

        /// <summary>
        /// Check if the coordinates are valid on this map
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>True if the given coordinates are correct</returns>
        private bool ValidCoordinates(int x, int y)
        {
            return x >= 0 && y >= 0 && x <= size && y <= size;
        }

        
        public Cell GetCell(int x, int y)
        {
            if (ValidCoordinates(x, y))
                return mapCells[x + y * size];
            else
                throw new InvalidCellException();
        }


        
        public bool CellIsAdjacentTo(int x, int y, int xTarget, int yTarget)
        {
            if (ValidCoordinates(x,y) && ValidCoordinates(xTarget,yTarget))
            {
               /// TODO: if (Math.Abs(x - xTarget) <= 1 && )
                return (x == xTarget && Math.Abs(y - yTarget) == 1) || (Math.Abs(x - xTarget) == 1 && (yTarget == y || yTarget == y - 1));
            }
            else
            {
                throw new InvalidCellException();
            }
        }


        public int Size
        {
            get { return (int)Math.Sqrt(mapCells.Length); }
        }


        public int getIndexFromCoodinates(int x, int y)
        {
            if (ValidCoordinates(x, y))
                return x + size * y;
            else
                throw new InvalidCellException();
        }
    }
}
