using PetitMonde.Map;
using PetitMonde.Map.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfSmallWorld
{
	public class MapView {
		public static Map Map { get; protected set; }
		public static Grid MapViewGrid { get; protected set; }
		public static Dictionary<int, CellView> cellViews { get; protected set; }

		/// <summary>
		/// Constructor to the view of the map
		/// </summary>
		/// <param name="_map">Reference to the Map model</param>
		/// <param name="_mapViewGrid">WPF Grid element</param>
		public MapView(Map _map, Grid _mapViewGrid) {
			Map = _map;
			MapViewGrid = _mapViewGrid;

			cellViews = new Dictionary<int,CellView>();

			for (int y = 0; y < Map.Size; y++)
			{
				for (int x = 0; x < Map.Size; x++)
				{
					CellView cell = new CellView(Map.GetCell(x,y),x,y);
					MapViewGrid.Children.Add(cell);
					cellViews.Add(Map.getIndexFromCoodinates(x,y), cell);
				}
			}
		}
	}
}
