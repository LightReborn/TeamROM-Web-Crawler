using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Data.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebCrawler.Data;
using WebCrawler.Model;
using WebCrawler.Data.DAL;


namespace WebCrawler.Data.Repos.Tests
{
    [TestClass()]
    public class GameRepositoryTests
    {

        

        [TestMethod()]
        public void GetGamesCountTest()
        {
          //arrange
            GameRepository gr = new GameRepository();
            
            //act
            // TODO:  ??? how to set up mock GameContext
            gr.generateFakeGameData();

            //assert


        }



        [TestMethod()]
        public void GetUniqueGamesCountTest()
        {
            GameRepository gr = new GameRepository();
            gr.generateFakeGameData();
            int expectedAnswer = 5;
            int testAnswer = gr.GetUniqueGamesCount();
            Assert.AreEqual(expectedAnswer, testAnswer);
        }

        [TestMethod()]
        public void GetUniqueGamesTest()
        {
            GameRepository gr = new GameRepository();
            gr.generateFakeGameData();
            //check that test list  equal actual list
        }

        [TestMethod()]
        public void GetGamesByNameTest()
        {

        }
    }
}
