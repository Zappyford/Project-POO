using PetitMonde.Units;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSmallWorld
{
    /// <summary>
    /// Logique d'interaction pour UnitView.xaml
    /// </summary>
    public partial class UnitView : UserControl
    {
        public Unit Unit { get; private set; }

        public UnitView(Unit u)
        {
            this.Unit = u;
            InitializeComponent();
            u.PropertyChanged += new PropertyChangedEventHandler(update);
        }

        private void update(object sender, PropertyChangedEventArgs e)
        {
            TranslateTransform trTns = new TranslateTransform(Unit.X * 60 + ((Unit.Y % 2 == 0) ? 0 : 30) - 640, Unit.Y * 50 - 370);
            TransformGroup trGrp = new TransformGroup();
            trGrp.Children.Add(trTns);
            grid.RenderTransform = trGrp;
        }

        private void OnUnitLoaded(object sender, RoutedEventArgs e)
        {
            update(this, null);
            this.SetAppearance();
        }

        private void SetAppearance()
        {
            switch (this.Unit.Faction)
            {
                case Faction.Dwarves:

                    break;
                case Faction.Elves:

                    break;
                case Faction.Orcs:

                    break;
            }
        }

    }
}
