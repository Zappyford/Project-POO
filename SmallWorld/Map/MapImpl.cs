using PetitMonde.Map.Cells;

namespace PetitMonde.Map
{
    public class MapImpl : Map
    {
        private CellFactory cellFactory = new CellFactory();
       
        public MapImpl(int size)
        {
            throw new System.NotImplementedException();
        }

        public PetitMonde.Map.Cells.CellImpl[] mapCells
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Cell GetCell(int x, int y)
        {
            throw new System.NotImplementedException();
        }




        public bool CellIsAdjacentTo(int x, int y, int xTarget, int yTarget)
        {
            throw new System.NotImplementedException();
        }
    }
}
