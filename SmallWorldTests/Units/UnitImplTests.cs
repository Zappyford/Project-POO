using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetitMonde.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PetitMonde.Units.Tests
{
    [TestClass()]
    public class UnitImplTests
    {
        Unit u;
        Unit opponentUnit;

        [TestInitialize]
        public void UnitImplTest()
        {
            u = new OrcUnit(0, 1);
            opponentUnit = new ElfUnit(1, 1);
        }

        [TestMethod()]
        public void MoveTest()
        {
            u.Move(1, 0);
            Assert.AreEqual(1, u.X);
            Assert.AreEqual(0, u.Y);
        }


        [TestMethod()]
        public void DieTest()
        {
            Assert.IsFalse(u.IsDead);
            u.Die();
            Assert.AreEqual(0, u.Health);
            Assert.IsTrue(u.IsDead);
        }


        [TestMethod()]
        public void AttackUnitTest()
        {
            CombatReport cr;
            cr = u.AttackUnit(opponentUnit);
            Assert.AreEqual(cr.AttackingUnitRetreat ? 1 : u.DefaultHealth + cr.AttackingUnitLostHealth, u.Health);
            Assert.AreEqual(cr.DefensingUnitRetreat ? 1 : opponentUnit.DefaultHealth + cr.DefensingUnitLostHealth, opponentUnit.Health);
        }
    }
}
