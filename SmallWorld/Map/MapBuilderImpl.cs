using PetitMonde.Map.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace PetitMonde.Map
{
    public abstract class MapBuilderImpl : PetitMonde.Map.MapBuilder
    {
        /// <summary>
        /// The cell factory
        /// </summary>
        private CellFactory cellFactory = new CellFactory();

        /// <summary>
        /// The size of the map
        /// </summary>
        protected abstract int Size
        {
            get;
        }

        public abstract int TurnsToPlay
        {
            get;
        }

        public Map BuildMap()
        {
            WrapperMapBuilder mBuilder = new WrapperMapBuilder();
            Map map = new MapImpl(Size);
            Cell[] cells;

            unsafe
            {
                int* cellNumbers = mBuilder.BuildMap(Size, 4);
                cells = new Cell[Size * Size];

                for (int i = 0; i < cells.Length; i++)
                {
                    cells[i] = cellFactory.createCell((CellType)cellNumbers[i]);
                }
            }

            map.mapCells = cells;
            return map;
        }


        public abstract int NumberOfUnits
        {
            get;
        }

    }

}
