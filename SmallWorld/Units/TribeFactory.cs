using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Units
{
    public class TribeFactory
    {
        public TribeFactory()
        {
            
        }
    
        public Tribe CreateOrcs()
        {
            return new Orcs();
        }

        public Tribe CreateElves()
        {
            return new Elves();
        }

        public Tribe CreateDwarves()
        {
            return new Dwarves();
        }
    }
}
