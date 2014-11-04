using PetitMonde.Map.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitMonde.Map.Cells
{
    public abstract class CellImpl : Cell
    {
        int x { get; protected set; }
        int y { get; protected set; }
        protected CellImpl(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
