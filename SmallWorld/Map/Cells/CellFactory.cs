
namespace PetitMonde.Map.Cells
{
    public class CellFactory
    {
        private readonly CellImpl Plain = new Plains();
        private readonly CellImpl Forest = new Forest();
        private readonly CellImpl Mountain = new Mountain();
        private readonly CellImpl Desert = new Desert();

        public CellFactory()
        {
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
