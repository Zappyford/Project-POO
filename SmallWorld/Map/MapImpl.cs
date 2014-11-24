using PetitMonde.Map.Cells;
using SmallWorld.Map;
using System;

namespace PetitMonde.Map
{
    public class MapImpl : Map
    {
        private CellFactory cellFactory = new CellFactory();
        private int size;

        public MapImpl(int size)
        {
            this.size = size;
            throw new System.NotImplementedException();
        }

        public PetitMonde.Map.Cells.CellImpl[] mapCells
        {
            get;
            set;
        }

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
                {

                }
            }
            else
            {
                throw new InvalidCellException();
            }
        }
    }
}
