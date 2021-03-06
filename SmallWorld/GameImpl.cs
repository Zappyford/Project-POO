﻿using PetitMonde.Units;
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

        private int XSelectedField;
        public int XSelected
        {
            get { 
                return XSelectedField;
            }
            set { 
                XSelectedField = value;
                OnPropertyChanged();
            }
        }

        private int YSelectedField;
        public int YSelected
        {
            get { 
                return YSelectedField; 
            }
            set { 
                YSelectedField = value; 
                OnPropertyChanged(); 
            }
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
            if (Map.ValidCoordinates(xTargeted,yTargeted) && unit.CanMove(xTargeted,yTargeted) && CurrentPlayer.Units.Contains(unit))
            {
                List<Unit> opponentPlayerUnits = OpponentPlayer.GetUnitsOnCell(xTargeted,yTargeted);
                if (opponentPlayerUnits.Count > 0)
                {
                    /// Il y a un combat
                    Unit opponentDefensiveUnit = OpponentPlayer.GetBestDefensiveUnit(xTargeted,yTargeted);
                    this.LastCombatReport = unit.AttackUnit(opponentDefensiveUnit);
                    //OnPropertyChanged();
                    ClearDeadUnits();
                    if (opponentDefensiveUnit.IsDead && OpponentPlayer.GetUnitsOnCell(xTargeted, yTargeted).Count==0)
                    {
                        // No more enemy unit on targeted cell
                        unit.Move(xTargeted, yTargeted);
                    }
                    else
                    {
                        unit.MovingPoints -= GameImpl.INSTANCE.Map.GetCell(xTargeted, yTargeted).GetMovingCost(unit.Faction);
                    }
                }
                else
                {
                    unit.Move(xTargeted, yTargeted);
                }
            }
        }

        public void EndTurn() {
            Player tmp = this.CurrentPlayer;
            CurrentPlayer.ClearMovingPoints();
            CurrentPlayer = OpponentPlayer;
            OpponentPlayer = tmp;

            if (System.Object.ReferenceEquals(CurrentPlayer, Player1))
                RemainingTurns--;
        }

        #region INotifyPropertyChanged

        [field: NonSerialized()]
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
            // Create folder if not exists
            string directory = Path.GetDirectoryName(path);
            if (!System.IO.Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Save file
            using (Stream FileStream = File.Create(path)) { 
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(FileStream, this);
            }
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


        public Player Winner
        {
            get {
                if (Player1.Score > Player2.Score)
                {
                    return Player1;
                }
                else if (Player1.Score < Player2.Score)
                {
                    return Player2;
                }
                else
                {
                    return null;
                }
            
            }
        }

        /// <summary>
        /// Clears the dead units froms lists of units
        /// </summary>
        private void ClearDeadUnits()
        {
            Player1.ClearDeadUnits();
            Player2.ClearDeadUnits();
        }

        [field: NonSerialized()]
        private CombatReport LastCombatReportField;


        public CombatReport LastCombatReport
        {
            get
            {
                return LastCombatReportField;
            }
            private set
            {
                LastCombatReportField = value;
                OnPropertyChanged();
            }
        }

    }
}
