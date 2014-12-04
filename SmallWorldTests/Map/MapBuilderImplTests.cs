using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetitMonde.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetitMonde.Map.Cells;
using System.Diagnostics;

namespace PetitMonde.Map.Tests
{
    [TestClass()]
    public class MapBuilderImplTests
    {
        [TestMethod()]
        public void BuildMapTest()
        {
            MapBuilder mapBuilder = new SmallMapBuilder();

            Map m = mapBuilder.BuildMap();

            Assert.AreEqual(100, m.mapCells.Length);

            /// Sélection du nombre d'occurrence de chaque type de cellule dans la carte
            IEnumerable<int> l =  m.mapCells.GroupBy(c => c.GetType())
                                            .Select(listTypes => listTypes.Count());
         
            
            foreach (int i in l)
            {
                // Chaque type de cellule doit être présent autant de fois
                Assert.AreEqual(m.mapCells.Length/4, i);
            }
        }
    }
}
