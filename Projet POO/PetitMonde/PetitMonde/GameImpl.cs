using System;

namespace PetitMonde
{
    public class GameImpl : PetitMonde.Game
    {
        public PetitMonde.PlayerImpl Player2
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public PetitMonde.PlayerImpl Player1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }


        public PetitMonde.Map.MapImpl Map
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


        public PetitMonde.PlayerImpl CurrentPlayer
        {
            get { throw new NotImplementedException(); }
        }

        public void AttackUnit(Units.Unit unit, Map.Cells.Cell dest)
        {
            throw new NotImplementedException();
        }


        public Player GetCurrentPlayer()
        {
            throw new NotImplementedException();
        }
    }
}
