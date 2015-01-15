using PetitMonde;
using PetitMonde.Units;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfSmallWorld
{
    /// <summary>
    /// Logique d'interaction pour InGame.xaml
    /// </summary>
    public partial class InGame : Window
    {
        List<MapUnitView> unitViews = new List<MapUnitView>();
        MapView mapView;
        private CombatReportView lastCombatReportView;


        /// <summary>
        /// Gets or sets the IsPaused field
        /// </summary>
        bool IsPaused
        {
            get;
            set;
        }

        private float moveOffsetX, moveOffsetY;

        /// <summary>
        /// Constructor for InGame
        /// </summary>
        public InGame()
        {
            InitializeComponent();
            IsPaused = false;
            mapView = new MapView(GameImpl.INSTANCE.Map, mapGrid);

            //to move the map at the center (depending on the size of the map)
            switch (MapView.Map.Size)
            {
                case 6:
                    moveOffsetX = (MapView.Map.Size * 55);
                    moveOffsetY = (MapView.Map.Size * 40);
                    break;
                case 10:
                    moveOffsetX = (MapView.Map.Size * 65);
                    moveOffsetY = (MapView.Map.Size * 40);
                    break;
                case 14:
                    moveOffsetX = (MapView.Map.Size * 61);
                    moveOffsetY = (MapView.Map.Size * 45);
                    break;
            }


            mapGrid.Margin = new Thickness(-moveOffsetX, -moveOffsetY, 0, 0);

            // Populate the map with the units
            foreach (Unit u in GameImpl.INSTANCE.Player1.Units)
            {
                unitViews.Add(new MapUnitView(u));
            }
            foreach (Unit u in GameImpl.INSTANCE.Player2.Units)
            {
                unitViews.Add(new MapUnitView(u));
            }
            foreach (MapUnitView uv in unitViews)
            {
                mapGrid.Children.Add(uv);
            }


            this.DataContext = this;

            lblCurrentPlayer.Content = GameImpl.INSTANCE.CurrentPlayer.Nickname;
            lblRemainingTurns.Content = GameImpl.INSTANCE.RemainingTurns + " turns left.";

            lblP1.Content = GameImpl.INSTANCE.Player1.Nickname;
            lblP2.Content = GameImpl.INSTANCE.Player2.Nickname;
            lblTribeP1.Content = GameImpl.INSTANCE.Player1.Tribe.FactionName;
            lblTribeP2.Content = GameImpl.INSTANCE.Player2.Tribe.FactionName;
            lblVictoryPointsP1.Content = "Victory points : " + GameImpl.INSTANCE.Player1.Score;
            lblVictoryPointsP2.Content = "Victory points : " + GameImpl.INSTANCE.Player2.Score;

            GameImpl.INSTANCE.PropertyChanged += new PropertyChangedEventHandler(update); // Souscription au OnPropertyChanged
        }

        /// <summary>
        /// Delegate called when a property is changed in GameImpl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void update(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "CurrentPlayer":
                    TryEndGame();
                    lblCurrentPlayer.Content = GameImpl.INSTANCE.CurrentPlayer.Nickname;
                    break;
                case "RemainingTurns":
                    lblRemainingTurns.Content = GameImpl.INSTANCE.RemainingTurns + " turns left.";
                    break;
                case "LastCombatReport":
                    ShowCombatReport();
                    deleteDeadUnits();
                    updateListUnits();
                    TryEndGame();
                    break;
                case "XSelected":
                case "YSelected":
                    updateListUnits();
                    break;
            }
        }

        private void ShowCombatReport()
        {
            VictoryPointsGrid.Children.Remove(this.lastCombatReportView);
            CombatReportView cr = new CombatReportView(GameImpl.INSTANCE.LastCombatReport);
            cr.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            cr.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            cr.Margin = new Thickness(0, 2*217, 0, 0);
            lastCombatReportView = cr;
            VictoryPointsGrid.Children.Add(cr);
        }

        /// <summary>
        /// Clears and updates the list of units of the selected cell
        /// </summary>
        private void updateListUnits()
        {
            listUnitGrid.Children.Clear();
            List<Unit> all = GameImpl.INSTANCE.Player1.Units.Concat(GameImpl.INSTANCE.Player2.Units).ToList();
            foreach (Unit u in all.Where(u => u.X == GameImpl.INSTANCE.XSelected && u.Y == GameImpl.INSTANCE.YSelected))
            {
                listUnitGrid.Children.Add(new FullUnitView(u));
            }
        }


        /// <summary>
        /// Delegete called when the end turn button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndTurn_Click(object sender, RoutedEventArgs e)
        {
            if (!IsPaused)
                GameImpl.INSTANCE.EndTurn();
            lblVictoryPointsP1.Content = "Victory points : " + GameImpl.INSTANCE.Player1.Score;
            lblVictoryPointsP2.Content = "Victory points : " + GameImpl.INSTANCE.Player2.Score;
        }

        /// <summary>
        /// Ends the game if a player has won
        /// </summary>
        private void TryEndGame()
        {
            if (GameImpl.INSTANCE.GameOver)
            {
                IsPaused = true;
                btnBack.Visibility = System.Windows.Visibility.Visible;
                Player Winner = GameImpl.INSTANCE.Winner;
                if (Winner != null)
                    lblVictory.Content = Winner.Nickname + " won !";
                else
                    lblVictory.Content = "It's a tie !";
                lblVictory.Visibility = System.Windows.Visibility.Visible;
            }

        }

        /// <summary>
        /// Delegate called when a key is pressed in the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowInGame_KeyUp(object sender, KeyEventArgs e)
        {
            Unit u = GameImpl.INSTANCE.SelectedUnit;
            int x = u != null ? u.X : 0;
            int y = u != null ? u.Y : 0;


            switch (e.Key)
            {
                case Key.Enter:
                    btnEndTurn_Click(sender, e);
                    break;
                case Key.Escape:
                    toggleMenu();
                    break;
                case Key.NumPad1:
                    GameImpl.INSTANCE.MoveUnit(u, y % 2 == 0 ? x + 1 : x, y % 2 == 0 ? y : y + 1);
                    break;
                case Key.NumPad3:
                    GameImpl.INSTANCE.MoveUnit(u, y % 2 == 0 ? x : x+1, y+1);
                    break;
                case Key.NumPad4:
                    GameImpl.INSTANCE.MoveUnit(u, x - 1, y);
                    break;
                case Key.NumPad6:
                    GameImpl.INSTANCE.MoveUnit(u, x + 1, y);
                    break;
                case Key.NumPad7:
                    GameImpl.INSTANCE.MoveUnit(u, y % 2 == 0 ? x-1 : x, y - 1);
                    break;
                case Key.NumPad9:
                    GameImpl.INSTANCE.MoveUnit(u, y % 2 == 0 ? x : x + 1, y-1);
                    break;
            }
        }

        /// <summary>
        /// Toggles the menu
        /// </summary>
        private void toggleMenu()
        {
            IsPaused = !IsPaused;
            main.Stretch = main.Stretch == Stretch.Uniform ? Stretch.Fill : Stretch.Uniform;
            MenuRectangle.IsEnabled = !MenuRectangle.IsEnabled;
            MenuRectangle.Visibility = MenuRectangle.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            btnContinue.Visibility = btnContinue.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            btnQuit.Visibility = btnQuit.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            btnSaveGame.Visibility = btnSaveGame.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            lblGamePaused.Visibility = lblGamePaused.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <summary>
        /// Delegate called when the continue button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            toggleMenu();
            main.Stretch = Stretch.Uniform;
        }

        /// <summary>
        /// Delegate called when the quit button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to quit this game?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Delegate called when the save game button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveGame_Click(object sender, RoutedEventArgs e)
        {
            SaveGame saveGameWindow = new SaveGame();
            saveGameWindow.Show();
        }

        /// <summary>
        /// Deletes the dead units's views from the map
        /// </summary>
        public void deleteDeadUnits()
        {
            foreach (UIElement uv in mapGrid.Children.Cast<UIElement>().ToArray())
            {
                if (uv is MapUnitView && ((MapUnitView)uv).Unit.IsDead)
                {
                    mapGrid.Children.Remove(uv);
                }
            }
            foreach (UIElement uv in listUnitGrid.Children.Cast<UIElement>().ToArray())
            {
                if (uv is FullUnitView && ((FullUnitView)uv).Unit.IsDead)
                {
                    mapGrid.Children.Remove(uv);
                }
            }
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }


    }
}
