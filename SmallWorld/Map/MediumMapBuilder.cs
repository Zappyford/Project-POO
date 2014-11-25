using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Map
{
    public class MediumMapBuilder : MapBuilderImpl
    {
        private const int DEFAULT_SIZE = 14;

        public MediumMapBuilder()
        {
            this.size = DEFAULT_SIZE;
        }
    
    }
}
