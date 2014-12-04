using System;

namespace PetitMonde.Map
{
    public class DemoMapBuilder : MapBuilderImpl
    {
        private const int DEFAULT_SIZE = 6;
        private const int DEFAULT_NUMBER_UNITS = 4;

        public override int numberOfUnits
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

        public DemoMapBuilder()
        {
        }
    }
}
