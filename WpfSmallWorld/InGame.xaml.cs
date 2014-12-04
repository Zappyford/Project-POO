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

        public InGame()
        {
            InitializeComponent();
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

        
        private void btnEndTurn_Click(object sender, RoutedEventArgs e)
        {
            GameImpl.INSTANCE.EndTurn();
        }

    }
}
