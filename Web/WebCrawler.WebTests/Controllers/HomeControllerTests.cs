using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using WebCrawler.Data.Repos;
using WebCrawler.Model.Models;
using Moq;
using WebCrawler.Data.DAL;

namespace WebCrawler.Web.Controllers.Tests
{
    // For each Controller --> test for
    //      Testing for ViewResult == vewiResult.ViewName
    //	    Testing of ViewData/ ViewBag
    //      Testing For RedirectResult

    [TestClass()]
    public class HomeControllerTests
    {
        
        [TestMethod()]
        public void IndexTestIsNull()
        {
            //arrange
            IGameRepository gameRepo = new WebCrawler.Data.Repos.GameRepository();
            var hc = new HomeController(gameRepo);

            //act
            var result = hc.Index() ;
            // var model = result.Model as (???)            
          
            //assert
            Assert.IsNull(result);
            //Assert.AreEqual("Gamer's Dungeon",  (???)    );
        }

        [TestMethod()]
        public void IndexTestNotNull()
        {
            //arrange
            // TODO:  how to mock dbcontext ???
            IGameRepository gameRepo = new WebCrawler.Data.Repos.GameRepository();
           
            
            var hc = new HomeController(gameRepo);

            //act
            var result = hc.Index();
            // var model = result.Model as (???)            

            //assert
            Assert.IsNull(result);
            //Assert.AreEqual("Gamer's Dungeon",  (???)    );
        }

        public void IndexTestCorrectType()
        {
            //arrange
            HomeController hc = new HomeController();
           
            //act
            ViewResult vr = hc.Index() as ViewResult;
           
            //assert
            Assert.IsInstanceOfType(vr, typeof(ViewResult));
        }

        [TestMethod()]
        public void IndexTestViewData()
        {
            //arrange
            HomeController hc = new HomeController();
            
            //act
            ViewResult vr = hc.Index() as ViewResult;
           
            //assert
            Assert.AreEqual("Gamer's Dungeon", vr.ViewData["Title"]);
        }

        [TestMethod()]
        public void IndexTestForIndexRedirectResult()
        {
            // ???  is there no Redirect ActionResult ?
        }

        [TestMethod()]
        public void GamesIndexTestNotNull()
        {
            //arrange
            HomeController hc = new HomeController();

            //act
            ViewResult vr = hc.GamesIndex() as ViewResult;

            //assert
            Assert.IsNotNull(vr);
        }

        [TestMethod()]
        public void GamesIndexTestCorrectType()
        {
            //arrange
            HomeController hc = new HomeController();
          
            //act
            ViewResult vr = hc.GamesIndex() as ViewResult;
           
            //assert
            Assert.IsInstanceOfType(vr, typeof(ViewResult));
        }

        [TestMethod()]
        public void GamesIndexTestViewData()
        {
            //arrange
            HomeController hc = new HomeController();
        
            //act
            ViewResult vr = hc.GamesIndex() as ViewResult;
         
            //assert
            Assert.AreEqual("Games Index", vr.ViewData["Title"]);
        }

        [TestMethod()]
        public void ProductPageTestNotNull()
        {
            //arrange
            HomeController hc = new HomeController();
            Game game = new Game();
            List<Game> gameList = new List<Game>();

            //act
            ViewResult vr = hc.ProductPage(game) as ViewResult;

            //assert
            Assert.IsNotNull(vr);
        }

        [TestMethod()]
        public void ProductPageTestCorrectType()
        {
            //arrange
            HomeController hc = new HomeController();
            Game game = new Game();
            List<Game> gameList = new List<Game>();

            //act
            ViewResult vr = hc.ProductPage(game) as ViewResult;

            //assert
            Assert.IsInstanceOfType(vr, typeof(ViewResult));
        }

        [TestMethod()]
        public void ProductPageTestViewData()
        {
            //arrange
            HomeController hc = new HomeController();
            Game game = new Game();
            List<Game> gameList = new List<Game>();

            //act
            ViewResult vr = hc.ProductPage(game) as ViewResult;

            //assert
            Assert.AreEqual("Game Page", vr.ViewData["Title"]);

        }

        [TestMethod()]
        public void ProductPageTestFor()
        {
            //arrange
            HomeController homeController = new HomeController();
            var mockRepository = new Mock<GameRepository>();
            var game = new Game();
            var listOfGames = new List<Game>();
            mockRepository.Setup(x => x.GetGamesByName(It.IsAny<String>())).Returns(listOfGames);

            //act
            var viewResult = homeController.ProductPage(game) as ViewResult;
            var list = viewResult.Model as List<Game>;
           
            //assert
            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(list);
        }

       

    }
}
