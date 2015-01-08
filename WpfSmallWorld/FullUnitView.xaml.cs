using PetitMonde;
using PetitMonde.Units;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSmallWorld
{
    /// <summary>
    /// Logique d'interaction pour FullUnitView.xaml
    /// </summary>
    public partial class FullUnitView : UserControl
    {
        public Unit Unit
        {
            get;
            private set;
        }

        public FullUnitView(Unit u)
        {
            Unit = u;
            InitializeComponent();
            u.PropertyChanged += new PropertyChangedEventHandler(update);
            GameImpl.INSTANCE.PropertyChanged += new PropertyChangedEventHandler(update);
            pbHealth.Maximum = Unit.DefaultHealth;
            pbHealth.Minimum = 0;
            pbMovingPoints.Maximum = Unit.DefaultMovingPoints;
            pbMovingPoints.Minimum = 0;
            lblAttack.Content = Unit.DefaultAttack;
            lblDefense.Content = Unit.DefaultDefense;
            grid.AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(grid_MouseLeftButtonDown), true);
        }
        

        protected void update(object sender, PropertyChangedEventArgs e){
            pbHealth.Value = Unit.Health;
            lblHealth.Content = Unit.Health + "/" + Unit.DefaultHealth;
            pbMovingPoints.Value = Unit.MovingPoints;
            lblMovingPoints.Content = Unit.MovingPoints + "/" + Unit.DefaultMovingPoints;

            if (Object.ReferenceEquals(GameImpl.INSTANCE.SelectedUnit,this.Unit))
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        protected void OnUnitLoaded(object sender, RoutedEventArgs e)
        {
            update(this, null);
            imgUnit.Source = Util.getImageResourceFromFaction(Unit.Faction);
        }

        private void grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(GameImpl.INSTANCE.CurrentPlayer.Units.Contains(this.Unit))
                GameImpl.INSTANCE.SelectedUnit = this.Unit;
        }
    }
}
