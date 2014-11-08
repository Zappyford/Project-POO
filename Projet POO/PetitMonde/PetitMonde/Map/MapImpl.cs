using PetitMonde.Map.Cells;
using System;

namespace PetitMonde.Map
{
    public class MapImpl : Map
    {
        public PetitMonde.Map.Cells.CellImpl[] mapCells
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Cell GetCell(int x, int y)
        {
            throw new System.NotImplementedException();
        }


        public Cell CreatePlains(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Cell CreateForest(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Cell CreateMountain(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Cell CreateDesert(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
