using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Map
{
    public class SmallMapBuilder : MapBuilderImpl
    {
        private const int DEFAULT_SIZE = 10;
        public SmallMapBuilder()
        {
            this.size = DEFAULT_SIZE;
        }
    
    }
}
