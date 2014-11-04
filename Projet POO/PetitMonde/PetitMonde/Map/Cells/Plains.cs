using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Map.Cells
{
    public class Plains : CellImpl
    {


        public Plains(int x, int y)
            : base(x, y)
        {
            
        }


        CellType Cell.Type
        {
            get { return CellType.Plains; }
        }

    }
}
