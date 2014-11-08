using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Map
{
    public abstract class MapBuilderImpl : PetitMonde.Map.MapBuilder
    {
    
        public abstract Map BuildMap();
    }
}
