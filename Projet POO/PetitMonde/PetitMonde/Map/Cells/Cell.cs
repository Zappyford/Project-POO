using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Map.Cells
{
     public interface Cell
    {

        public abstract float GetMovingCost(Faction faction);

    }
       
 
}
