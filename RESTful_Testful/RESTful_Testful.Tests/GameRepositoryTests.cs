using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RESTful_Testful.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace RESTful_Testful.Models.Tests
{
    [TestClass()]
    public class GameRepositoryTests
    {
        [TestMethod()]
        public void GameRepositoryTestIsNotNull()
        {
            // arrange
            GameRepository gr = new GameRepository();

            //act

            //assert
            Assert.IsNotNull(gr);
        }

        [TestMethod()]
        public void GameRepositoryTestIsCorrectType()
        {
            // arrange
            GameRepository gr = new GameRepository();

            //act

            //assert
            Assert.IsInstanceOfType(gr, typeof(GameRepository));
        }

        [TestMethod()]
        public void GetAllTest()
        {

            // arrange
            GameRepository gr = new GameRepository();
            List<Game> gameList = new List<Game>();

            //act
            gr.GetAll();

            //assert
            Assert.IsNotNull(gameList);
        }

        [TestMethod()]
        public void GetTestIsCorrectType()
        {
            //arrange
            GameRepository gr = new GameRepository();

            //act
            Game game = gr.Get(2);

            //assert
            Assert.IsInstanceOfType(game, typeof(Game));
        }

        [TestMethod()]
        public void GetTestReturnsCorrectGame()
        {
            //arrange
            GameRepository gr = new GameRepository();

            //act
            Game game = gr.Get(2);
            int id = game.ID;

            //assert
            Assert.AreEqual(id, 2);
        }


        [TestMethod()]
        public void AddTestIfGame()
        {
            //arrange
            Game game = new Game();
            game.ID = 1;
            game.Name = "testGame";
            GameRepository gr = new GameRepository();

            //act
            Game game2 = gr.Add(game);

            //assert
            Assert.AreEqual(game2.Name, "testGame");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTestIfGameIsNull()
        {
            //arrange
            Game game = null;
            GameRepository gr = new GameRepository();

            //act
            Game nullGame = gr.Add(game);

            //assert
            Assert.IsNull(nullGame);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            //arrange
            GameRepository gr = new GameRepository();
           
            //act
            gr.Remove(1);
            
            //assert
            Assert.AreEqual(gr.gameList.Count, 1);        
        }

        [TestMethod()]
        public void RemoveTest2()
        {
            //arrange
            GameRepository gr = new GameRepository();

            //act
            gr.Remove(1);

            //assert
            Assert.AreNotEqual(gr.gameList.Count, 3);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateTestIfGameIsNull()
        {

            //arrange
            GameRepository gr = new GameRepository();
            Game game = null;

            //act
            gr.Update(game);


            //assert
            // test should fail, therefore never reach this line
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTestIfGameIsNotNull()
        {
            //arrange
            GameRepository gr = new GameRepository();
            Game game = gr.gameList.ElementAt(0);

            //act
            bool gameWasUpdated = gr.Update(game);

            //assert
            Assert.IsTrue(gameWasUpdated);
        }


    }
}
