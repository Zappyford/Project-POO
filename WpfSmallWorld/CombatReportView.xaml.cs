using PetitMonde.Units;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour CombatReport.xaml
    /// </summary>
    public partial class CombatReportView : UserControl
    {
        public CombatReportView(CombatReport cr)
        {
            InitializeComponent();
            this.DataContext = cr;



            FullUnitView attackingUnitView = new FullUnitView(cr.AttackingUnit);
            FullUnitView defensingUnitView = new FullUnitView(cr.DefensingUnit);
            attackingUnitView.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            attackingUnitView.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            defensingUnitView.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            defensingUnitView.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            attackingUnitView.Margin = new Thickness(0, 50, 0, 0);
            defensingUnitView.Margin = new Thickness(0, 0, 0, 0);

            grid.Children.Add(attackingUnitView);
            grid.Children.Add(defensingUnitView);

            /*
            this.lblAttackingUnitDead.Visibility = cr.AttackingUnitDead ? Visibility.Visible : System.Windows.Visibility.Collapsed;
            this.lblDefensingUnitDead.Visibility = cr.DefensingUnitDead ? Visibility.Visible : System.Windows.Visibility.Collapsed;

            this.lblAttackingUnitLostHealth.Content = "-" + cr.AttackingUnitLostHealth;
            this.lblDefensingUnitLostHealth.Content = "-" + cr.Def;
             * */

        }
    }
}
