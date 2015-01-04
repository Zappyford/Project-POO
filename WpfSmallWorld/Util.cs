using PetitMonde.Units;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfSmallWorld
{
    public static class Util
    {
        private static string[] ImageResourceNameFromFaction;
        private static ResourceManager rm = new System.Resources.ResourceManager("WpfSmallWorld.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());

        static Util()
        {
            ImageResourceNameFromFaction = new string[Enum.GetNames(typeof(Faction)).Length];
            ImageResourceNameFromFaction[(int)Faction.Orcs] = "Orc";
            ImageResourceNameFromFaction[(int)Faction.Dwarves] = "Dwarf";
            ImageResourceNameFromFaction[(int)Faction.Elves] = "Elf";
        }

        private static string getImageResourceNameFromFaction(Faction f)
        {
            return ImageResourceNameFromFaction[(int)f];
        }

        public  static BitmapSource getImageResourceFromFaction(Faction f){
            Bitmap imageP1 = (Bitmap)rm.GetObject(getImageResourceNameFromFaction(f));
            Int32Rect rectP1 = new Int32Rect(0, 0, imageP1.Width, imageP1.Height);
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(imageP1.GetHbitmap(), IntPtr.Zero, rectP1, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
