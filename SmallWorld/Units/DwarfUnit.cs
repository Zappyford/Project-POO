using PetitMonde.Map.Cells;
using System;

namespace PetitMonde.Units
{
    [Serializable()]
    public class DwarfUnit : UnitImpl
    {
        public DwarfUnit(int defaultX, int DefaultY)
            : base(defaultX, DefaultY)
        {
            Faction = Faction.Dwarves;
        }

        public override bool CanMove(int x, int y)
        {
            /// Dwarves can move on all the map, if the cell and the Targeted cell are both Mountains
            Cell targetedCell =  GameImpl.INSTANCE.Map.GetCell(x, y);
            Cell cell = GameImpl.INSTANCE.Map.GetCell(X,Y);

            return base.CanMove(x,y) || (targetedCell.getType() == CellType.Mountain && cell.getType() == CellType.Mountain);
        }

        public override float ChanceOfRetreat
        {
            get { return 0; }
        }
    }
}
