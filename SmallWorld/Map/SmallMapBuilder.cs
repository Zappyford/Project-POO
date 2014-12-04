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
        private const int DEFAULT_NUMBER_TURNS = 20;

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


        public SmallMapBuilder()
        {
        }
    
    }
}
