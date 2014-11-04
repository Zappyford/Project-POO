using PetitMonde.Map.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Map.Cells
{
    public class CellFactory
    {

        public Cell createPlains(int x, int y)
        {
            return new Plains(x,y);
        }

        public Cell createForest(int x, int y)
        {
            return new Forest(x,y);
        }

        public Cell createMountain(int x, int y)
        {
            return new Mountain(x,y);
        }

        public Cell createDesert(int x, int y)
        {
            return new Desert(x,y);
        }
    }
}
