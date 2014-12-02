using System;
using System.Collections.Generic;
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
using PetitMonde;
using PetitMonde.Units;
using PetitMonde.Map;
using System.Drawing;

namespace WpfSmallWorld
{
    /// <summary>
    /// Logique d'interaction pour NewGame.xaml
    /// </summary>
    public partial class NewGame : Window
    {
        string[] ImageResourceNameFromFaction;

        NewGameDataContext dataContext = new NewGameDataContext();

        ResourceManager rm = new System.Resources.ResourceManager("WpfSmallWorld.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());

        public NewGame()
        {
            InitializeComponent();
            this.DataContext = dataContext;
            ImageResourceNameFromFaction = new string[3];
            ImageResourceNameFromFaction[(int)Faction.Orcs] = "Orc";
            ImageResourceNameFromFaction[(int)Faction.Dwarves] = "Dwarf";
            ImageResourceNameFromFaction[(int)Faction.Elves] = "Elf";

        }

        private void rbOrcsP1_Checked(object sender, RoutedEventArgs e)
        {
            if (rbOrcsP2.IsChecked.HasValue && rbOrcsP2.IsChecked.Value)
            {
                rbElvesP2.IsChecked = true;
            }
            tbkTribeDescriptionP1.Text = rm.GetString("DescriptionOrcs");
            updateFactionImages();
        }

        private void rbDwarvesP1_Checked(object sender, RoutedEventArgs e)
        {
            if (rbDwarvesP2.IsChecked.HasValue && rbDwarvesP2.IsChecked.Value)
            {
                rbOrcsP2.IsChecked = true;
            }
            tbkTribeDescriptionP1.Text = rm.GetString("DescriptionDwarves");
            updateFactionImages();
           
        }

        private void rbElvesP1_Checked(object sender, RoutedEventArgs e)
        {
            if (rbElvesP2.IsChecked.HasValue && rbElvesP2.IsChecked.Value)
            {
                rbDwarvesP2.IsChecked = true;
            }
            tbkTribeDescriptionP1.Text = rm.GetString("DescriptionElves");
            updateFactionImages();
        }

        private void rbDwarvesP2_Checked(object sender, RoutedEventArgs e)
        {
            if (rbDwarvesP1.IsChecked.HasValue && rbDwarvesP1.IsChecked.Value)
            {
                rbOrcsP1.IsChecked = true;
            }
            tbkTribeDescriptionP2.Text = rm.GetString("DescriptionDwarves");
            updateFactionImages();
        }

        private void rbOrcsP2_Checked(object sender, RoutedEventArgs e)
        {
            if (rbOrcsP1.IsChecked.HasValue && rbOrcsP1.IsChecked.Value)
            {
                rbElvesP1.IsChecked = true;
            }
            tbkTribeDescriptionP2.Text = rm.GetString("DescriptionOrcs");
            updateFactionImages();
        }

        private void rbElvesP2_Checked(object sender, RoutedEventArgs e)
        {
            if (rbElvesP1.IsChecked.HasValue && rbElvesP1.IsChecked.Value)
            {
                rbDwarvesP1.IsChecked = true;
            }
            tbkTribeDescriptionP2.Text = rm.GetString("DescriptionElves");
            updateFactionImages();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            // TODO
            GameBuilder gameBuilder = (GameBuilder)new PetitMonde.NewGame(this.dataContext);
            gameBuilder.BuildGame();
        }

        /// <summary>
        /// Updates the faction images
        /// </summary>
        private void updateFactionImages()
        {
            Bitmap imageP1 = (Bitmap)rm.GetObject(getImageResourceNameFromFaction(dataContext.FactionP1));
            Int32Rect rectP1 = new Int32Rect(0, 0, imageP1.Width, imageP1.Height);
            BitmapSource srcP1 = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(imageP1.GetHbitmap(), IntPtr.Zero, rectP1, BitmapSizeOptions.FromEmptyOptions());
            this.imgFactionP1.Source = srcP1;

            Bitmap imageP2 = (Bitmap)rm.GetObject(getImageResourceNameFromFaction(dataContext.FactionP2));
            Int32Rect rectP2 = new Int32Rect(0, 0, imageP2.Width, imageP2.Height);
            BitmapSource srcP2 = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(imageP2.GetHbitmap(), IntPtr.Zero, rectP2, BitmapSizeOptions.FromEmptyOptions());
            this.imgFactionP2.Source = srcP2;
        }

        private string getImageResourceNameFromFaction(Faction f)
        {
            return ImageResourceNameFromFaction[(int)f];
        }
    }
    
   
}
