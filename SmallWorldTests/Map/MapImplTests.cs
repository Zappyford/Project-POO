using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetitMonde.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PetitMonde.Map.Tests
{
    [TestClass()]
    public class MapImplTests
    {
        Map m;
        [TestInitialize]
        public void MapImplTest()
        {
            MapBuilder mb = new MediumMapBuilder();
            m = mb.BuildMap();
        }

        [TestMethod()]
        public void GetCellTest()
        {

        }

        [TestMethod()]
        public void CellIsAdjacentToTest()
        {

            // Tests for odd y
            int x = 4;
            int y = 3;
            Assert.IsTrue(m.CellIsAdjacentTo(x, y, x-1,y));
            Assert.IsTrue(m.CellIsAdjacentTo(x, y, x, y-1)); 
            Assert.IsTrue(m.CellIsAdjacentTo(x, y, x + 1, y-1));
            Assert.IsTrue(m.CellIsAdjacentTo(x, y, x + 1, y));
            Assert.IsTrue(m.CellIsAdjacentTo(x, y, x + 1, y+1));
            Assert.IsTrue(m.CellIsAdjacentTo(x, y, x, y+1));
            Assert.IsFalse(m.CellIsAdjacentTo(x, y, x - 1, y - 1));
            Assert.IsFalse(m.CellIsAdjacentTo(x, y, x - 1, y + 1));

            // Tests for even y
            y = 2;
            Assert.IsTrue(m.CellIsAdjacentTo(x, y, x - 1, y));
            Assert.IsTrue(m.CellIsAdjacentTo(x, y, x, y - 1));
            Assert.IsTrue(m.CellIsAdjacentTo(x, y, x - 1, y - 1));
            Assert.IsTrue(m.CellIsAdjacentTo(x, y, x + 1, y));
            Assert.IsTrue(m.CellIsAdjacentTo(x, y, x - 1, y + 1));
            Assert.IsTrue(m.CellIsAdjacentTo(x, y, x, y + 1));
            Assert.IsFalse(m.CellIsAdjacentTo(x, y, x + 1, y - 1));
            Assert.IsFalse(m.CellIsAdjacentTo(x, y, x + 1, y + 1));

        }

        [TestMethod()]
        public void getIndexFromCoodinatesTest()
        {

        }
    }
}
