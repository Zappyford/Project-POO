using System;
using PetitMonde.Map.Cells;

namespace PetitMonde.Map
{
    public interface Map
    {
        Cell[] mapCells { get; set; }
        
        Cell getCell(int x, int y);
    }
}
