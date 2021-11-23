using Game.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GameTest.Repos
{
    [TestClass]
    public class GameReposTest
    {
        [TestMethod]
        public void InitialiteOptions_ExecutionDone_GetOptionsList()
        {
            // arrange
            var gameRepos = new GameRepos();
                       

            //act
            var resultOption = gameRepos.InitialiteOptions();

            //assert
            
            Assert.IsNotNull(resultOption[0]);            
            Assert.AreEqual(0, resultOption[0].IdOption);
            Assert.AreEqual("Rock", resultOption[0].Name);
            Assert.AreEqual(1, resultOption[0].strongerOptions.Count);
            Assert.AreEqual("Paper", resultOption[0].strongerOptions[0].Name);

            Assert.IsNotNull(resultOption[1]);
            Assert.AreEqual(1, resultOption[1].IdOption);
            Assert.AreEqual("Paper", resultOption[1].Name);
            Assert.AreEqual(2, resultOption[1].strongerOptions.Count);
            Assert.AreEqual("Scissors", resultOption[1].strongerOptions[0].Name);
            Assert.AreEqual("Flamethrower", resultOption[1].strongerOptions[1].Name);

            Assert.IsNotNull(resultOption[2]);
            Assert.AreEqual(2, resultOption[2].IdOption);
            Assert.AreEqual("Scissors", resultOption[2].Name);
            Assert.AreEqual(1, resultOption[2].strongerOptions.Count);
            Assert.AreEqual("Rock", resultOption[2].strongerOptions[0].Name);

            Assert.IsNotNull(resultOption[3]);
            Assert.AreEqual(3, resultOption[3].IdOption);
            Assert.AreEqual("Flamethrower", resultOption[3].Name);
            Assert.AreEqual(2, resultOption[3].strongerOptions.Count);
            Assert.AreEqual("Rock", resultOption[3].strongerOptions[0].Name);
            Assert.AreEqual("Scissors", resultOption[3].strongerOptions[1].Name);
        }

        [TestMethod]
        public void InitialitePlayers_OnlyHumans_GetPlayerList()
        {
            // arrange
            var gameRepos = new GameRepos();
            
            gameRepos.InitialitePlayers(false, false);

            //act
            var resultOption = gameRepos.InitialitePlayers(true, false);

            //assert
            Assert.IsFalse(resultOption[0].IsComputerPlayer);
            Assert.IsFalse(resultOption[1].IsComputerPlayer);
            
        }

        [TestMethod]
        public void InitialitePlayers_VsComputerNotRandom_GetPlayerList()
        {
            // arrange
            var gameRepos = new GameRepos();

            gameRepos.InitialitePlayers(false, false);

            //act
            var resultOption = gameRepos.InitialitePlayers(false, false);

            //assert
            Assert.IsFalse(resultOption[0].IsComputerPlayer);
            Assert.IsTrue(resultOption[1].IsComputerPlayer);
            Assert.IsFalse(resultOption[1].RandomSelection);
        }

        [TestMethod]
        public void InitialitePlayers_VsComputerRandom_GetPlayerList()
        {
            // arrange
            var gameRepos = new GameRepos();

            gameRepos.InitialitePlayers(false, false);

            //act
            var resultOption = gameRepos.InitialitePlayers(false, true);

            //assert
            Assert.IsFalse(resultOption[0].IsComputerPlayer);
            Assert.IsTrue(resultOption[1].IsComputerPlayer);
            Assert.IsTrue(resultOption[1].RandomSelection);
        }

        [TestMethod]
        public void GetComputerOption_NotRandomSelectionRock_GetComputerOption()
        {
            // arrange
            var gameRepos = new GameRepos();
            gameRepos.InitialiteOptions();
            gameRepos.InitialitePlayers(false, false);

            //act
           var resultOption= gameRepos.GetComputerOption(0);

            //assert

            Assert.AreEqual("Paper", resultOption.Name);
            Assert.AreEqual(1, resultOption.IdOption);            
        }

        [TestMethod]
        public void GetComputerOption_NotRandomSelectionPaper_GetComputerOption()
        {
            // arrange
            var gameRepos = new GameRepos();
            gameRepos.InitialiteOptions();
            gameRepos.InitialitePlayers(false, false);

            //act
            var resultOption = gameRepos.GetComputerOption(1);

            //assert

            Assert.AreEqual("Scissors", resultOption.Name);
            Assert.AreEqual(2, resultOption.IdOption);
        }

        [TestMethod]
        public void GetComputerOption_NotRandomSelectionScissors_GetComputerOption()
        {
            // arrange
            var gameRepos = new GameRepos();
            gameRepos.InitialiteOptions();
            gameRepos.InitialitePlayers(false, false);

            //act
            var resultOption = gameRepos.GetComputerOption(2);

            //assert

            Assert.AreEqual("Rock", resultOption.Name);
            Assert.AreEqual(0, resultOption.IdOption);
        }

        [TestMethod]
        public void GetComputerOption_NotRandomSelectionFlamethrower_GetComputerOption()
        {
            // arrange
            var gameRepos = new GameRepos();
            gameRepos.InitialiteOptions();
            gameRepos.InitialitePlayers(false, false);

            //act
            var resultOption = gameRepos.GetComputerOption(3);

            //assert

            Assert.AreEqual("Rock", resultOption.Name);
            Assert.AreEqual(0, resultOption.IdOption);
        }

        [TestMethod]
        public void GetComputerOption_RandomSelectionScissors_GetComputerOption()
        {
            // arrange
            var gameRepos = new GameRepos();
            gameRepos.InitialiteOptions();
            gameRepos.InitialitePlayers(false, true);

            //act
            var resultOption = gameRepos.GetComputerOption(2);

            //assert

            Assert.IsNotNull(resultOption);
            Assert.AreNotEqual("", resultOption.Name);
        }

        [TestMethod]
        public void DetermineIfIAmAWinner_RockVsPaper_GetRockNotWin()
        {
            // arrange
            var gameRepos = new GameRepos();
            var optrionsList = gameRepos.InitialiteOptions();

            //act
            var resultOption = gameRepos.DetermineIfIAmAWinner(optrionsList[0], optrionsList[1]);

            //assert
            Assert.IsFalse(resultOption);
        }

        [TestMethod]
        public void DetermineIfIAmAWinner_RockVsScissors_GetRocktWin()
        {
            // arrange
            var gameRepos = new GameRepos();
            var optrionsList = gameRepos.InitialiteOptions();

            //act
            var resultOption = gameRepos.DetermineIfIAmAWinner(optrionsList[0], optrionsList[2]);

            //assert
            Assert.IsTrue(resultOption);
        }

        [TestMethod]
        public void DetermineIfIAmAWinner_RockVsFlamethrower_GetRocktWin()
        {
            // arrange
            var gameRepos = new GameRepos();
            var optrionsList = gameRepos.InitialiteOptions();

            //act
            var resultOption = gameRepos.DetermineIfIAmAWinner(optrionsList[0], optrionsList[3]);

            //assert
            Assert.IsTrue(resultOption);
        }

        [TestMethod]
        public void DetermineIfIAmAWinner_PaperVsRock_GetRocktWin()
        {
            // arrange
            var gameRepos = new GameRepos();
            var optrionsList = gameRepos.InitialiteOptions();

            //act
            var resultOption = gameRepos.DetermineIfIAmAWinner(optrionsList[1], optrionsList[0]);

            //assert
            Assert.IsTrue(resultOption);
        }

        [TestMethod]
        public void DetermineIfIAmAWinner_PaperVsScissors_GetRocktWin()
        {
            // arrange
            var gameRepos = new GameRepos();
            var optrionsList = gameRepos.InitialiteOptions();

            //act
            var resultOption = gameRepos.DetermineIfIAmAWinner(optrionsList[1], optrionsList[2]);

            //assert
            Assert.IsFalse(resultOption);
        }

        [TestMethod]
        public void DetermineIfIAmAWinner_PaperVsFlamethrower_GetRocktWin()
        {
            // arrange
            var gameRepos = new GameRepos();
            var optrionsList = gameRepos.InitialiteOptions();

            //act
            var resultOption = gameRepos.DetermineIfIAmAWinner(optrionsList[1], optrionsList[3]);

            //assert
            Assert.IsFalse(resultOption);
        }


        [TestMethod]
        public void DetermineIfIAmAWinner_ScissorsVsRock_GetRocktWin()
        {
            // arrange
            var gameRepos = new GameRepos();
            var optrionsList = gameRepos.InitialiteOptions();

            //act
            var resultOption = gameRepos.DetermineIfIAmAWinner(optrionsList[2], optrionsList[0]);

            //assert
            Assert.IsFalse(resultOption);
        }

        [TestMethod]
        public void DetermineIfIAmAWinner_ScissorsVsPaper_GetRocktWin()
        {
            // arrange
            var gameRepos = new GameRepos();
            var optrionsList = gameRepos.InitialiteOptions();

            //act
            var resultOption = gameRepos.DetermineIfIAmAWinner(optrionsList[2], optrionsList[1]);

            //assert
            Assert.IsTrue(resultOption);
        }

        [TestMethod]
        public void DetermineIfIAmAWinner_ScissorsVsFlamethrower_GetRocktWin()
        {
            // arrange
            var gameRepos = new GameRepos();
            var optrionsList = gameRepos.InitialiteOptions();

            //act
            var resultOption = gameRepos.DetermineIfIAmAWinner(optrionsList[2], optrionsList[3]);

            //assert
            Assert.IsTrue(resultOption);
        }

        [TestMethod]
        public void DetermineIfIAmAWinner_FlamethrowerVsRock_GetRocktWin()
        {
            // arrange
            var gameRepos = new GameRepos();
            var optrionsList = gameRepos.InitialiteOptions();

            //act
            var resultOption = gameRepos.DetermineIfIAmAWinner(optrionsList[3], optrionsList[0]);

            //assert
            Assert.IsFalse(resultOption);
        }

        [TestMethod]
        public void DetermineIfIAmAWinner_FlamethrowerVsPaper_GetRocktWin()
        {
            // arrange
            var gameRepos = new GameRepos();
            var optrionsList = gameRepos.InitialiteOptions();

            //act
            var resultOption = gameRepos.DetermineIfIAmAWinner(optrionsList[3], optrionsList[1]);

            //assert
            Assert.IsTrue(resultOption);
        }

        [TestMethod]
        public void DetermineIfIAmAWinner_FlamethrowerVsScissors_GetRocktWin()
        {
            // arrange
            var gameRepos = new GameRepos();
            var optrionsList = gameRepos.InitialiteOptions();

            //act
            var resultOption = gameRepos.DetermineIfIAmAWinner(optrionsList[3], optrionsList[2]);

            //assert
            Assert.IsFalse(resultOption);
        }

    }
}
