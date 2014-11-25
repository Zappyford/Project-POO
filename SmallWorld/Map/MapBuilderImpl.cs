using PetitMonde.Map.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            // Index of each cell type to place
            const int mountainIndex = 0;
            const int desertIndex = 1;
            const int plainsIndex = 2;
            const int forestIndex = 3;

            // The tab of cells is initialized with size^2 cells.
            int numberOfCells = (int)Math.Pow(size, 2);
            Cell[] cells = new Cell[numberOfCells];

            int numberOfEachCell = numberOfCells / 4;
            // Array that stores the number of case of each type left to place
            int[] tabCellTypeLeft = { numberOfEachCell, numberOfEachCell, numberOfEachCell, numberOfEachCell };

            Map map = new MapImpl(size);
            Random randomGenerator = new Random();

            

            for (int i = 0; i < numberOfCells; i++)
            {
                int rand = randomGenerator.Next(0, 4);
                bool canPlace = false;

                // Vérification de la possibilité de placer ce type de case
                while (!canPlace)
                {
                    if (tabCellTypeLeft[rand] > 0) // Si au moins une case de ce type est disponible, on peut placer
                        canPlace = true;
                    else // Sinon on regénère un nombre, jusqu'à tomber sur un valide
                        rand = randomGenerator.Next(0, 4);
                }

                switch (rand)
                {
                    case mountainIndex:
                        cells[i] = cellFactory.CreateMountain();
                        tabCellTypeLeft[mountainIndex]--;
                        break;
                    case desertIndex:
                        cells[i] = cellFactory.CreateDesert();
                        tabCellTypeLeft[desertIndex]--;
                        break;
                    case plainsIndex:
                        cells[i] = cellFactory.CreatePlains();
                        tabCellTypeLeft[plainsIndex]--;
                        break;
                    case forestIndex:
                        cells[i] = cellFactory.CreateForest();
                        tabCellTypeLeft[forestIndex]--;
                        break;
                }
            }

            map.mapCells = cells;
            return map;
        }
    }
}
