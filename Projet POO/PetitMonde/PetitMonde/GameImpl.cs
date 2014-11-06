using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde
{
    public class GameImpl : PetitMonde.Game
    {
        public Player Player2
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Player Player1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }


        public Map.Map Map
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public Player CurrentPlayer
        {
            get { throw new NotImplementedException(); }
        }

        public void AttackUnit(Units.Unit unit, Map.Cells.Cell dest)
        {
            throw new NotImplementedException();
        }
    }
}
