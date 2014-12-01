using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Map
{
    public class SmallMapBuilder : MapBuilderImpl
    {
        private const int DEFAULT_SIZE = 10;

        private const int DEFAULT_NUMBER_UNITS = 6;

        public override int numberOfUnits
        {
            get
            {
                return DEFAULT_NUMBER_UNITS;
            }
        }

        public SmallMapBuilder()
        {
            this.size = DEFAULT_SIZE;
        }
    
    }
}
