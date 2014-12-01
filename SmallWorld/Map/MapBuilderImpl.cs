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
        protected int size;

        public Map BuildMap()
        {
            WrapperMapBuilder mBuilder = new WrapperMapBuilder();
            Map map = new MapImpl(size);
            Cell[] cells;

            unsafe
            {
                int* cellNumbers = mBuilder.BuildMap(size, 4);
                cells = new Cell[size * size];



                
                for(int i = 0; i<cells.Length; i++){

                    cells[i] = cellFactory.createCell((CellType)cellNumbers[i]);

                    /*
                    switch(cellNumbers[i]){
                        case (int)CellType.Desert:
                            cells[i] = cellFactory.CreateDesert();
                            break;
                        case (int)CellType.Mountain:
                            cells[i]= cellFactory.CreateMountain();
                            break;
                        case (int)CellType.Forest:
                            cells[i] = cellFactory.CreateForest();
                            break;
                        case (int)CellType.Plains:
                            cells[i] = cellFactory.CreatePlains();
                            break;
                     */
                    }
            }
           
            map.mapCells = cells;
            return map;
        }


        public abstract int numberOfUnits
        {
            get;
        }
    }
}
