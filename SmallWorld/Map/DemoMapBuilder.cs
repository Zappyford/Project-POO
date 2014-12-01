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

        public DemoMapBuilder()
        {
            this.size = DEFAULT_SIZE;
        }
    }
}
