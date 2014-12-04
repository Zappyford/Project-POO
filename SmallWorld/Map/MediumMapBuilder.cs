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
        private const int DEFAULT_NUMBER_TURNS = 30;

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


        public MediumMapBuilder()
        {

        }
    
    }
}
