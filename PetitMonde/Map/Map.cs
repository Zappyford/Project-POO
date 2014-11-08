using System;
using PetitMonde.Map.Cells;

namespace PetitMonde.Map
{
    public interface Map
    {
        
        Cell GetCell(int x, int y);

        public Cell CreatePlains(int x, int y);

        public Cell CreateForest(int x, int y);

        public Cell CreateMountain(int x, int y);

        public Cell CreateDesert(int x, int y);

    }
}
