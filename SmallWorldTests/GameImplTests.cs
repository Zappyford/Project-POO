using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetitMonde;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PetitMonde.Tests
{
    [TestClass()]
    public class GameImplTests
    {
        

        [TestInitialize]
        public void UnitImplTest()
        {
            NewGameDataContext dataContext = new NewGameDataContext();
            dataContext.FactionP1 = Units.Faction.Dwarves;
            dataContext.FactionP2 = Units.Faction.Elves;
            dataContext.NicknameP1 = "Player1";
            dataContext.NicknameP2 = "Player2";
            dataContext.SizeOfMap = Map.MapSize.medium;
            GameBuilder gameBuilder = (GameBuilder)new PetitMonde.NewGame(dataContext);
            gameBuilder.BuildGame();
        }

        [TestMethod()]
        public void MoveUnitTest()
        {

        }

        [TestMethod()]
        public void EndTurnTest()
        {

        }

        [TestMethod()]
        public void OnPropertyChangedTest()
        {

        }

        [TestMethod()]
        public void saveTest()
        {
            
            string saveDir = Environment.CurrentDirectory+ "\\save.sav";
            Console.WriteLine("Writing test save at the path : " + saveDir);
            GameImpl.INSTANCE.save(saveDir);
        }
    }
}
