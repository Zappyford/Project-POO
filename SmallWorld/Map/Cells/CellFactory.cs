
namespace PetitMonde.Map.Cells
{
    public class CellFactory
    { /*
        private readonly CellImpl Plain = new Plains();
        private readonly CellImpl Forest = new Forest();
        private readonly CellImpl Mountain = new Mountain();
        private readonly CellImpl Desert = new Desert();
       * */
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

        /*
        public Cell CreatePlains()
        {
            return Plain;
        }

        public Cell CreateForest()
        {
            return Forest;
        }

        public Cell CreateMountain()
        {
            return Mountain;
        }

        public Cell CreateDesert()
        {
            return Desert;
        }
         * */
    }
}
