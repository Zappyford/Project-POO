using System;

namespace PetitMonde.Map
{
    public class DemoMapBuilder : MapBuilderImpl
    {
        private const int DEFAULT_SIZE = 6;
        public DemoMapBuilder()
        {
            this.size = DEFAULT_SIZE;
        }
    }
}
