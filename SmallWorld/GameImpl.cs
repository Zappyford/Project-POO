using PetitMonde.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetitMonde
{
    public class GameImpl : PetitMonde.Game
    {
        public static readonly GameImpl INSTANCE = new GameImpl();

        public PetitMonde.Player Player2
        {
            get;
            set;
        }

        public PetitMonde.Player Player1
        {
            get;
            set;
        }


        public PetitMonde.Map.Map Map
        {
            get;
            set;
        }


        public PetitMonde.Player CurrentPlayer
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

        public Player OpponentPlayer
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


        public void MoveUnit(Unit unit, int xTargeted, int yTargeted)
        {
            if (unit.CanMove(xTargeted,yTargeted) && CurrentPlayer.Units.Contains(unit))
            {
                List<Unit> opponentPlayerUnits = OpponentPlayer.GetUnitsOnCell(xTargeted,yTargeted);
                if (opponentPlayerUnits.Count > 0)
                {
                    /// Il y a un combat
                    unit.AttackUnit(OpponentPlayer.GetBestDefensiveUnit(xTargeted,yTargeted));
                    /// TODO
                }
                else
                {
                    unit.Move(xTargeted, yTargeted);
                }
            }
            else
            {
                /// On tente de déplacer l'unité de l'ennemi
            }
        }

        public void EndTurn() {
            Player tmp = this.CurrentPlayer;
            
            CurrentPlayer = OpponentPlayer;
            OpponentPlayer = tmp;
        }
    }
}
