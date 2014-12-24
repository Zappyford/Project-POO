using PetitMonde;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour SaveGame.xaml
    /// </summary>
    public partial class SaveGame : Window
    {
        private ResourceManager rm = new System.Resources.ResourceManager("WpfSmallWorld.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
        private SaveGameDataContext dataContext = new SaveGameDataContext();
        private readonly String path;

        public SaveGame()
        {
            InitializeComponent();
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + rm.GetString("SmallWorldSaveFolder");
            listSavedGames.ItemsSource = findSavedGames();
            this.DataContext = dataContext;
            dataContext.path = path + "\\" + tbNameGame.Text;
            this.dataContext.PropertyChanged += new PropertyChangedEventHandler(update); // Souscription au OnPropertyChanged
        }

        private void update(object sender, PropertyChangedEventArgs e)
        {
            if (path != null)
            {
                tbNameGame.Text = dataContext.path.Remove(0, path.Length + 1).Replace(".sav", "");
                if (listSavedGames.Items.Contains(tbNameGame.Text))
                {
                    listSavedGames.SelectedItem = tbNameGame.Text;
                }
                else
                {
                    listSavedGames.SelectedItem = null;
                }
            }
        }

        /// <summary>
        /// Lists all files contained in the ApplicationData\Roaming\SmallWorld folder
        /// </summary>
        /// <returns>A list containing the name of each file</returns>
        private IEnumerable<String> findSavedGames()
        {
            List<string> res = new List<string>();

            if (Directory.Exists(path))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);

                FileInfo[] info = dirInfo.GetFiles("*.sav");
                foreach (FileInfo f in info)
                {
                    res.Add(f.Name.Replace(".sav", ""));
                }
            }
            return res;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void listSavedGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataContext.path = path + "\\" + listSavedGames.SelectedItem;
        }

        private void btnSaveGame_Click(object sender, RoutedEventArgs e)
        {
             MessageBoxResult result = MessageBoxResult.Yes;
            /// TODO
            if (File.Exists(dataContext.path))
            {
                result = MessageBox.Show("Are you sure you the previously saved game named \"" + dataContext.path.Remove(0, path.Length + 1).Replace(".sav", "") +"\"?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            }

            if (result == MessageBoxResult.Yes)
            {
                GameImpl.INSTANCE.save(dataContext.path + ".sav");   
            }
           
            this.Close();
        }

        private void tbNameGame_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                tbNameGame.Text = tbNameGame.Text.Replace(c.ToString(), "");
            }

            dataContext.path = path + "\\" + tbNameGame.Text;
        }
    }
}
