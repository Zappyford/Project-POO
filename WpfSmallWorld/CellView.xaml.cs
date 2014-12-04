using PetitMonde;
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
        public bool IsSelected
        {
            get
            {
                return GameImpl.INSTANCE.YSelected == Y && GameImpl.INSTANCE.XSelected == X;
            }
            set
            {
                if (value)
                {
                    GameImpl.INSTANCE.XSelected = X;
                    GameImpl.INSTANCE.YSelected = Y;
                    this.bgPath.Opacity = 0.4;
                }
                else
                {
                    GameImpl.INSTANCE.XSelected = -1;
                    GameImpl.INSTANCE.YSelected = -1;
                    this.bgPath.Opacity = 1;
                }
            }
        }

        public int X
        {
            get;
            private set;
        }
        public int Y
        {
            get;
            private set;
        }
        static string[] brushResourceNameFromCellType;
        public CellView(Cell c, int x, int y)
        {
            InitializeComponent();
            this.bgPath.Fill = (Brush)grid.Resources[brushResourceNameFromCellType[(int)c.getType()]];
            X = x;
            Y = y;
            
        }

        static CellView()
        {
            brushResourceNameFromCellType = new string[4];
            brushResourceNameFromCellType[(int)CellType.Desert] = "BrushDesertCell";
            brushResourceNameFromCellType[(int)CellType.Plains] = "BrushPlainCell"; 
            brushResourceNameFromCellType[(int)CellType.Forest] = "BrushForestCell";
            brushResourceNameFromCellType[(int)CellType.Mountain] = "BrushMountainCell";
        }

        private void OnCellViewLoaded(object sender, RoutedEventArgs e)
        {
            // Set position (hexagon disposition)
            TranslateTransform trTns = new TranslateTransform(X * 60 + ((Y % 2 == 0) ? 0 : 30) - 640, Y * 50 - 370);
            TransformGroup trGrp = new TransformGroup();
            trGrp.Children.Add(trTns);

            grid.RenderTransform = trGrp;

     //       currentState = TileViewState.Idle;
       //     SetGround();
        }

        private void hexagonPath_MouseEnter(object sender, MouseEventArgs e)
        {
            this.hexagonPath.Opacity = 1;
        }

        private void hexagonPath_MouseLeave(object sender, MouseEventArgs e)
        {
            this.hexagonPath.Opacity = 0;
        }

        private void bgPath_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MapView.cellViews[GameImpl.INSTANCE.Map.getIndexFromCoodinates(GameImpl.INSTANCE.XSelected, GameImpl.INSTANCE.YSelected)].IsSelected = false;
            this.IsSelected = true;
        }
    }
}
