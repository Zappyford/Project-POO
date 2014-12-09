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
        ResourceManager rm = new System.Resources.ResourceManager("WpfSmallWorld.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
        public FindSavedGame()
        {
            InitializeComponent();
            listSavedGames.ItemsSource = findSavedGames();
        }

        private IEnumerable<String> findSavedGames()
        {

            List<string> res = new List<string>();
            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + rm.GetString("SmallWorldSaveFolder");

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


    }
}
