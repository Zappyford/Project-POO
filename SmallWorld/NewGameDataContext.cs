using PetitMonde.Map;
using PetitMonde.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitMonde
{
    public class NewGameDataContext
    {
        public Faction FactionP1
        {
            get;
            set;
        }
        public Faction FactionP2
        {
            get;
            set;
        }
        public MapSize SizeOfMap
        {
            get;
            set;
        }

        public string NicknameP1 { get; set; }

        public string NicknameP2 { get; set; }
    }
}
