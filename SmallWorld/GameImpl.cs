using PetitMonde.Units;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace PetitMonde
{
    [Serializable()]
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
            using (Stream TestFileStream = File.Create(path)) { 
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(TestFileStream, this);
             }
            /*
            using (System.IO.StreamWriter file = File.CreateText(path))
            {
                file.Write(JsonConvert.SerializeObject(this));
            }
             * */
        }

        /// <summary>
        /// Loads the given game into the INSTANCE
        /// </summary>
        /// <param name="g">The game to load</param>
        public static void load(GameImpl g)
        {
            GameImpl.INSTANCE.Map = g.Map;
            GameImpl.INSTANCE.Player1 = g.Player1;
            GameImpl.INSTANCE.Player2 = g.Player2;
            GameImpl.INSTANCE.OpponentPlayer = g.OpponentPlayer;
            GameImpl.INSTANCE.RemainingTurns = g.RemainingTurns;
            GameImpl.INSTANCE.SelectedUnit = g.SelectedUnit;
            GameImpl.INSTANCE.CurrentPlayer = g.CurrentPlayer;
            GameImpl.INSTANCE.XSelected = g.XSelected;
            GameImpl.INSTANCE.YSelected = g.YSelected;
        }
    }
}
