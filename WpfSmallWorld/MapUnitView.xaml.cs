using PetitMonde;
using PetitMonde.Units;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSmallWorld
{
    /// <summary>
    /// Logique d'interaction pour UnitView.xaml
    /// </summary>
    public partial class MapUnitView : UserControl
    {
        private string[] ImageResourceNameFromFaction;
        private ResourceManager rm = new System.Resources.ResourceManager("WpfSmallWorld.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
        protected static Random rand = new Random();


        public Unit Unit { get; private set; }

        public MapUnitView(Unit u)
        {
            this.Unit = u;
            InitializeComponent();


            ImageResourceNameFromFaction = new string[Enum.GetNames(typeof(Faction)).Length];
            ImageResourceNameFromFaction[(int)Faction.Orcs] = "Orc";
            ImageResourceNameFromFaction[(int)Faction.Dwarves] = "Dwarf";
            ImageResourceNameFromFaction[(int)Faction.Elves] = "Elf";
            u.PropertyChanged += new PropertyChangedEventHandler(update);
        }

        protected virtual void update(object sender, PropertyChangedEventArgs e)
        {
            TranslateTransform trTns = new TranslateTransform(Unit.X * 60 + ((Unit.Y % 2 == 0) ? 0 : 30), Unit.Y * 50);
            TransformGroup trGrp = new TransformGroup();
            trGrp.Children.Add(trTns);
            grid.RenderTransform = trGrp;
            if (GameImpl.INSTANCE.CurrentPlayer.GetUnitsOnCell(Unit.X, Unit.Y).Count > 1)
            {
                int randMarginX = rand.Next(-10, 15);
                int randMarginY = rand.Next(-20, 15);

                this.Margin = new Thickness(randMarginX, randMarginY, -randMarginX, -randMarginY);
            }
        }

        protected void OnUnitLoaded(object sender, RoutedEventArgs e)
        {
            update(this, null);
            this.SetAppearance();
        }

        private void SetAppearance()
        {
            Bitmap imageP1 = (Bitmap)rm.GetObject(getImageResourceNameFromFaction(Unit.Faction));
            Int32Rect rectP1 = new Int32Rect(0, 0, imageP1.Width, imageP1.Height);
            BitmapSource srcP1 = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(imageP1.GetHbitmap(), IntPtr.Zero, rectP1, BitmapSizeOptions.FromEmptyOptions());
            this.sprite.Source = srcP1;
        }

        private string getImageResourceNameFromFaction(Faction f)
        {
            return ImageResourceNameFromFaction[(int)f];
        }

    }
}
