using PetitMonde.Map.Cells;
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
    /// Logique d'interaction pour CellView.xaml
    /// </summary>
    public partial class CellView : UserControl
    {

        static string[] brushResourceNameFromCellType;
        public CellView(Cell c)
        {
            InitializeComponent();
            this.hexagonPath.Fill = (Brush)FindResource(brushResourceNameFromCellType[(int)c.getType()]);
        }

        static CellView()
        {
            brushResourceNameFromCellType = new string[4];
            brushResourceNameFromCellType[(int)CellType.Desert] = "BrushDesertCell";
            brushResourceNameFromCellType[(int)CellType.Plains] = "BrushPlainCell"; 
            brushResourceNameFromCellType[(int)CellType.Forest] = "BrushForestCell";
            brushResourceNameFromCellType[(int)CellType.Mountain] = "BrushMountainCell";
        }
    }
}
