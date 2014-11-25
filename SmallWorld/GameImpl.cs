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
            set;
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

        /// <summary>
        /// Private constructor (singleton)
        /// </summary>
        private GameImpl()
        {

        }


        public void AttackUnit(Unit unit, int xTargeted, int yTargeted)
        {
            throw new NotImplementedException();
        }
    }
}
