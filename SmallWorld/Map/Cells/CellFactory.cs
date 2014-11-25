
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
    }
}
