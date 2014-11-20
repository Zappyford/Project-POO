using PetitMonde.Units;
using System;

namespace PetitMonde
{
    public class GameImpl : PetitMonde.Game
    {
        public static readonly GameImpl INSTANCE = new GameImpl();

        public PetitMonde.PlayerImpl Player2
        {
            get;
            set;
        }

        public PetitMonde.PlayerImpl Player1
        {
            get;
            set;
        }


        public PetitMonde.Map.MapImpl Map
        {
            get;
            set;
        }


        public PetitMonde.PlayerImpl CurrentPlayer
        {
            get;
            protected set;
        }

        public Unit SelectedUnit
        {
            get;
            set;
        }

        public int XSelected
        {
            get;
            set;
        }

        public int YSelected
        {
            get;
            set;
        }

        public PlayerImpl OpponentPlayer
        {
            get;
            set;
        }

        private GameImpl()
        {

        }
        public void AttackUnit(Units.Unit unit, Map.Cells.Cell dest)
        {
            throw new NotImplementedException();
        }


        public Player GetCurrentPlayer()
        {
            throw new NotImplementedException();
        }


        public Player GetOpponentPlayer()
        {
            throw new NotImplementedException();
        }
    }
}
