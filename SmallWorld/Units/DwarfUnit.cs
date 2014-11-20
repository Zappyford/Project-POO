using PetitMonde.Map.Cells;
using System;

namespace PetitMonde.Units
{
    public class DwarfUnit : UnitImpl
    {
        public DwarfUnit(int defaultX, int DefaultY)
            : base(defaultX, DefaultY)
        {
            Faction = PetitMonde.Faction.Dwarves;
        }

        public override bool CanMove(int x, int y)
        {
            Cell targetedCell =  GameImpl.INSTANCE.Map.GetCell(x, y);
            Cell cell = GameImpl.INSTANCE.Map.GetCell(X,Y);

            return base.CanMove(x,y) || (targetedCell.getType() == CellType.Mountain && cell.getType() == CellType.Mountain);
        }
    }
}
