using System;

namespace PetitMonde.Map
{
    public class DemoMapBuilder : MapBuilderImpl
    {
        private const int DEFAULT_SIZE = 6;
        private const int DEFAULT_NUMBER_UNITS = 4;
        private const int DEFAULT_NUMBER_TURNS = 5;

        public override int NumberOfUnits
        {
            get
            {
                return DEFAULT_NUMBER_UNITS;
            }
        }

        protected override int Size
        {
            get
            {
                return DEFAULT_SIZE;
            }
        }

        public override int TurnsToPlay
        {
            get { return DEFAULT_NUMBER_TURNS; }
        }

        public DemoMapBuilder()
        {
        }
    }
}
