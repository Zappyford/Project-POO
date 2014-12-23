
namespace PetitMonde.Map.Cells
{
    public class CellFactory
    { 
        private CellImpl[] tabCells;


        public CellFactory()
        {
            tabCells = new CellImpl[4];
            tabCells[(int)CellType.Desert] = new Desert();
            tabCells[(int)CellType.Plains] = new Plains();
            tabCells[(int)CellType.Mountain] = new Mountain();
            tabCells[(int)CellType.Forest] = new Forest();
        }

        public Cell createCell(CellType cellType){
            return tabCells[(int)cellType];
        }

    }
}
