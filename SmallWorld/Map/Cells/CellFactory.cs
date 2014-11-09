
namespace PetitMonde.Map.Cells
{
    public class CellFactory
    {
        private const CellImpl Plain = new Plains();
        private const CellImpl Forest = new Forest();
        private const CellImpl Mountain = new Mountain();
        private const CellImpl Desert = new Desert();

        public CellFactory()
        {
            throw new System.NotImplementedException();
        }

        public Cell CreatePlains(int x, int y)
        {
            return Plain;
        }

        public Cell CreateForest(int x, int y)
        {
            return Forest;
        }

        public Cell CreateMountain(int x, int y)
        {
            return Mountain;
        }

        public Cell CreateDesert(int x, int y)
        {
            return Desert;
        }
    }
}
