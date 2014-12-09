using PetitMonde;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
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
    /// Logique d'interaction pour FindSavedGame.xaml
    /// </summary>
    public partial class FindSavedGame : Window
    {
        private ResourceManager rm = new System.Resources.ResourceManager("WpfSmallWorld.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
        private SavedGameDataContext dataContext = new SavedGameDataContext();
        private readonly String path;

        public FindSavedGame()
        {
            InitializeComponent();
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + rm.GetString("SmallWorldSaveFolder");
            listSavedGames.ItemsSource = findSavedGames();
            if (listSavedGames.Items.Count > 0)
                listSavedGames.SelectedItem = listSavedGames.Items.GetItemAt(0);
            else
                btnLoadGame.IsEnabled = false;
            this.DataContext = dataContext;
        }

        /// <summary>
        /// Lists all files contained in the ApplicationData\Roaming\SmallWorld folder
        /// </summary>
        /// <returns>A list containing the name of each file</returns>
        private IEnumerable<String> findSavedGames()
        {
            List<string> res = new List<string>();
            

            /// Debug
            Console.WriteLine("Find saved games Path : " + path);
            /// /Debug


            if (Directory.Exists(path))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);

                FileInfo[] info = dirInfo.GetFiles("*.*");
                foreach (FileInfo f in info)
                {
                    res.Add(f.Name);
                }
            }
            return res;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void listSavedGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataContext.path = path + "\\" + listSavedGames.SelectedItem;
        }

        private void btnLoadGame_Click(object sender, RoutedEventArgs e)
        {
            GameBuilder gameBuilder = (GameBuilder)new PetitMonde.SavedGame(this.dataContext);
            gameBuilder.BuildGame();
            Window w = new InGame();
            w.Show();
            this.Close();
        }


    }
}
