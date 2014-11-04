using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Map.Cells
{
    public class Desert : CellImpl
    {


        public Desert(int x, int y)
            : base(x, y)
        {

        }


        CellType Cell.Type
        {
            get { return CellType.Desert; }
        }

    }
}
