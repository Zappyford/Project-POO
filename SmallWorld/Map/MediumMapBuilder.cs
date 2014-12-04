using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Map
{
    public class MediumMapBuilder : MapBuilderImpl
    {
        private const int DEFAULT_SIZE = 14;
        private const int DEFAULT_NUMBER_UNITS = 8;

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

        public MediumMapBuilder()
        {

        }
    
    }
}
