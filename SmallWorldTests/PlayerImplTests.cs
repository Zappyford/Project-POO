﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetitMonde;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetitMonde.Units;
namespace PetitMonde.Tests
{
    [TestClass()]
    public class PlayerImplTests
    {
        Player p;
        Player p2;

        [TestInitialize()]
        public void PlayerImplTest()
        {
            p = new PlayerImpl(new Orcs(), 0,1,12,"jeu");
            p2 = new PlayerImpl(new Elves(), 0, 2, 12, "opponent");
        }

        [TestMethod()]
        public void EndTurnTest()
        {
            p.EndTurn();
            Assert.ReferenceEquals(p2, GameImpl.INSTANCE.CurrentPlayer);
            Assert.ReferenceEquals(p, GameImpl.INSTANCE.OpponentPlayer);
        }
        [TestMethod()]
        public void FightTest()
        {
            p.Fight(p.GetUnitsOnCell(0, 1).Find(u => true), p2.GetBestDefensiveUnit(0, 2));
        }

        [TestMethod()]
        public void GetUnitsOnCellTest()
        {

            List<Unit> allUnitsList = p.GetUnitsOnCell(0, 1);
            List<Unit> emptyList = p.GetUnitsOnCell(0, 0);

            Assert.AreEqual(12, allUnitsList.Count);
            Assert.AreEqual(0, emptyList.Count);
        }

        [TestMethod()]
        public void GetBestDefensiveUnitTest()
        {
            ((PlayerImpl)p).Units.ElementAt(2).Health += 2;
            Unit u = p.GetBestDefensiveUnit(0, 1);

            Assert.ReferenceEquals(p.Units.ElementAt(2), u); 
        }
    }
}
