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

            this.DataContext = cr;

            grid.Children.Add(new FullUnitView(cr.AttackingUnit));
            grid.Children.Add(new FullUnitView(cr.DefensingUnit));


            /*
            this.lblAttackingUnitDead.Visibility = cr.AttackingUnitDead ? Visibility.Visible : System.Windows.Visibility.Collapsed;
            this.lblDefensingUnitDead.Visibility = cr.DefensingUnitDead ? Visibility.Visible : System.Windows.Visibility.Collapsed;

            this.lblAttackingUnitLostHealth.Content = "-" + cr.AttackingUnitLostHealth;
            this.lblDefensingUnitLostHealth.Content = "-" + cr.Def;
             * */
            InitializeComponent();
        }
    }
}
