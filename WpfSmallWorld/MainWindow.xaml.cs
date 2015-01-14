using PetitMonde;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSmallWorld
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame newGameWindow = new NewGame();
            newGameWindow.Show();
            this.Close();
        }

        private void btnLoadGame_Click(object sender, RoutedEventArgs e)
        {
            FindSavedGame findSavedGameWindow = new FindSavedGame();
            findSavedGameWindow.Show();
            this.Close();
            /*
            String path = @"c:\save.sav";
            SavedGameDataContext data = new SavedGameDataContext();
            data.path = path;
            GameBuilder gameBuilder = new SavedGame(data);
            gameBuilder.BuildGame();
             * */
        }

    }
}
