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

namespace WpfSmallWorld
{
    /// <summary>
    /// Logique d'interaction pour NewGame.xaml
    /// </summary>
    public partial class NewGame : Window
    {
        ResourceManager rm = new System.Resources.ResourceManager("WpfSmallWorld.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());

        public NewGame()
        {
            InitializeComponent();
        }

        private void rbOrcsP1_Checked(object sender, RoutedEventArgs e)
        {
            if (rbOrcsP2.IsChecked.HasValue && rbOrcsP2.IsChecked.Value)
            {
                rbElvesP2.IsChecked = true;
            }
            tbkTribeDescriptionP1.Text = rm.GetString("DescriptionOrcs");
        }

        private void rbDwarvesP1_Checked(object sender, RoutedEventArgs e)
        {
            if (rbDwarvesP2.IsChecked.HasValue && rbDwarvesP2.IsChecked.Value)
            {
                rbOrcsP2.IsChecked = true;
            }
            tbkTribeDescriptionP1.Text = rm.GetString("DescriptionDwarves");
        }

        private void rbElvesP1_Checked(object sender, RoutedEventArgs e)
        {
            if (rbElvesP2.IsChecked.HasValue && rbElvesP2.IsChecked.Value)
            {
                rbDwarvesP2.IsChecked = true;
            }
            tbkTribeDescriptionP1.Text = rm.GetString("DescriptionElves");
        }

        private void rbDwarvesP2_Checked(object sender, RoutedEventArgs e)
        {
            if (rbDwarvesP1.IsChecked.HasValue && rbDwarvesP1.IsChecked.Value)
            {
                rbOrcsP1.IsChecked = true;
            }
            tbkTribeDescriptionP2.Text = rm.GetString("DescriptionDwarves");
        }

        private void rbOrcsP2_Checked(object sender, RoutedEventArgs e)
        {
            if (rbOrcsP1.IsChecked.HasValue && rbOrcsP1.IsChecked.Value)
            {
                rbElvesP1.IsChecked = true;
            }
            tbkTribeDescriptionP2.Text = rm.GetString("DescriptionOrcs");
        }

        private void rbElvesP2_Checked(object sender, RoutedEventArgs e)
        {
            if (rbElvesP1.IsChecked.HasValue && rbElvesP1.IsChecked.Value)
            {
                rbDwarvesP1.IsChecked = true;
            }
            tbkTribeDescriptionP2.Text = rm.GetString("DescriptionElves");
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
           // GameBuilder gm = (GameBuilder)new PetitMonde.NewGame(tbNicknameP1.Text, tbNicknameP2.Text);
        }

    }
}
