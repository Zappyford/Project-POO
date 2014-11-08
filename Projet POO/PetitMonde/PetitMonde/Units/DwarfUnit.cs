using System;

namespace PetitMonde.Units
{
    public class DwarfUnit : UnitImpl
    {
        public DwarfUnit(int defaultX, int DefaultY) : base(defaultX,DefaultY)
        {
        }

        public override bool CanMove(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
