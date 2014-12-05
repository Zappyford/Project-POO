using Newtonsoft.Json;
using PetitMonde.Units;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PetitMonde
{
    public class GameImpl : PetitMonde.Game, INotifyPropertyChanged
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

        private int _remainingTurns;
        public int RemainingTurns
        {
            get
            {
                return _remainingTurns;
            }
            set
            {
                _remainingTurns = value > 0 ? value : 0;
                OnPropertyChanged();
            }
        }

        public bool GameOver
        {
            get
            {
                return RemainingTurns == 0 || Player1.HasLost || Player2.HasLost;
            }
        }

        private Player _currentPlayer;
        public PetitMonde.Player CurrentPlayer
        {
            get
            {
                return _currentPlayer;
            }
            set
            {
                _currentPlayer = value;
                OnPropertyChanged();
            }
        }

        private Unit _selectedUnit;
        public Unit SelectedUnit
        {
            get
            {
                return _selectedUnit;
            }
            set
            {
                _selectedUnit = value;
                OnPropertyChanged();
            }
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
            CurrentPlayer.clearMovingPoints();
            CurrentPlayer = OpponentPlayer;
            OpponentPlayer = tmp;

            if (System.Object.ReferenceEquals(CurrentPlayer, Player1))
                RemainingTurns--;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion


        public void save(string path)
        {

            using (System.IO.StreamWriter file = File.CreateText(path))
            {
                file.Write(JsonConvert.SerializeObject(this));
            }
        }
    }
}
