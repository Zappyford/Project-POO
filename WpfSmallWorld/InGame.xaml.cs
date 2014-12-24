using PetitMonde;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        MapView mapView;

        /// <summary>
        /// Gets or sets the IsPaused field
        /// </summary>
        bool IsPaused { get; set; }

        public InGame()
        {
            InitializeComponent();
            IsPaused = false;
            mapView = new MapView(GameImpl.INSTANCE.Map, mapGrid);
            this.DataContext = GameImpl.INSTANCE;

            lblCurrentPlayer.Content = GameImpl.INSTANCE.CurrentPlayer.Nickname + "'s turn.";
            lblRemainingTurns.Content = GameImpl.INSTANCE.RemainingTurns + " turns left.";

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
                    lblCurrentPlayer.Content = GameImpl.INSTANCE.CurrentPlayer.Nickname + "'s turn.";
                    break;
                case "SelectedUnit":
                    
                    break;
                case "RemainingTurns":
                    lblRemainingTurns.Content = GameImpl.INSTANCE.RemainingTurns + " turns left.";
                    break;

            }
        }

        /// <summary>
        /// Delegete called when the end turn button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndTurn_Click(object sender, RoutedEventArgs e)
        {
            if(!IsPaused)
                GameImpl.INSTANCE.EndTurn();
        }

        /// <summary>
        /// Delegate called when a key is pressed in the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowInGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnEndTurn_Click(sender, e);
            }
            else if (e.Key == Key.Escape)
            {
                toggleMenu();
            }
        }

        private void toggleMenu(){
            IsPaused = !IsPaused;
            MenuRectangle.Height = WindowInGame.ActualHeight;
            MenuRectangle.Width = WindowInGame.ActualWidth;
            MenuRectangle.IsEnabled = !MenuRectangle.IsEnabled;
            MenuRectangle.Visibility = MenuRectangle.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            btnContinue.Visibility = btnContinue.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            btnQuit.Visibility = btnQuit.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            btnSaveGame.Visibility = btnSaveGame.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            lblGamePaused.Visibility = lblGamePaused.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            toggleMenu();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to quit this game?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnSaveGame_Click(object sender, RoutedEventArgs e)
        {
            SaveGame saveGameWindow = new SaveGame();
            saveGameWindow.Show();
        }

    }
}
