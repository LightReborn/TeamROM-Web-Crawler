using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RESTful_Testful.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RESTful_Testful.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;


namespace RESTful_Testful.Controllers.Tests
{
    [TestClass()]
    public class GameControllerTests
    {
        [TestMethod()]
        public void GetAllGamesTestIsCorrectType()
        {
            //arrange
            GameRepository gr = new GameRepository();
            GameController gc = new GameController(gr);

            //act
            IEnumerable<Game> listOfAllGames = gc.databasePlaceholder.GetAll();

            //assert
            Assert.IsInstanceOfType(listOfAllGames, typeof(IEnumerable<Game>));

        }

        [TestMethod()]
        public void GetAllGamesTestIsNotNull()
        {
            //arrange
            GameRepository gr = new GameRepository();
            GameController gc = new GameController(gr);

            //act
            IEnumerable<Game> listOfAllGames = gc.databasePlaceholder.GetAll();

            //assert
            Assert.IsNotNull(listOfAllGames);
        }

        [TestMethod()]
        public void GetGameByIDTestForType()
        {
            //arrange
            GameRepository gr = new GameRepository();
            GameController gc = new GameController(gr);
            Game game = new Game();

            //act
            game = gc.GetGameByID(0);

            //assert
            Assert.IsInstanceOfType(game, typeof(Game));
        }

        [TestMethod()]
        public void GetGameByIDTestForNotNull()
        {
            //arrange
            GameRepository gr = new GameRepository();
            GameController gc = new GameController(gr);
            Game game = new Game();

            //act
            // there exists no id=3, therefore, should return null
            game = gc.GetGameByID(1);

            //assert
            Assert.IsNotNull(game);
        }

        // TODO:  fix, 
        //          this is correct idea, but an error exists


        [TestMethod()]
        [ExpectedException(typeof(HttpResponseException))]
        public void GetGameByIDTestForIfNullThrowException()
        {
            //arrange
            GameRepository gr = new GameRepository();
            GameController gc = new GameController(gr);
            Game game = new Game();

            //act
            // there exists no id=3, therefore, should return null
            game = gc.GetGameByID(3);

            //assert
            //if method passes -> code will not reach this line
            Assert.Fail();
        }


        //    //https://www.asp.net/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api
        //    [TestMethod()]
        //    public void PostGameTestForReturnHttpResponseMessage()
        //    {
        //        //arrange
        //        var mockIGameRepos = new Moq.Mock<IGameRepository>();
        //        Game game = null;
        //        mockIGameRepos.Setup(g => g.Get(It.IsAny<int>())).Returns(game);
        //        RESTful_Testful.Controllers.GameController gc = new GameController(mockIGameRepos.Object);
        //        gc.Request = new HttpRequestMessage 
        //        {
        //            RequestUri = new Uri("http://localhost/api/products");

        //        };

        //        gc.Configuration= new HttpConfiguration();
        //        gc.Configuration.Routes.MapHttpBatchRoute
        //            (
        //             name: "DefaultApi", 
        //    routeTemplate: "api/{controller}/{id}",
        //    defaults: new { id = RouteParameter.Optional }

        //            );
        //        gc.RequestContext.RouteData = new HttpRouteData 
        //        (
        //        route: new HttpRoute(), 
        //        values: new HttpRouteValueDictionary{{"controller", "products"}}
        //        );

        //         // Act
        //Product product = new Product() { Id = 42, Name = "Product1" };
        //var response = controller.Post(product);

        //// Assert
        //Assert.AreEqual("http://localhost/api/products/42", response.Headers.Location.AbsoluteUri);


        //      }

        [TestMethod()]
        public void PutGameTest()
        {
            //arrange
            GameRepository gr = new GameRepository();
            GameController gc = new GameController(gr);
            Game game = gc.databasePlaceholder.gameList.ElementAt(0);

            //act
            bool gameWasPut = gc.PutGame(game);

            //assert
            Assert.IsTrue(gameWasPut);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PutGameTestExceptionHandling()
        {
            //arrange
            GameRepository gr = new GameRepository();
            GameController gc = new GameController(gr);
            Game game = null;

            //act
            bool gameWasPut = gc.PutGame(game);

            //assert
            Assert.IsTrue(gameWasPut);
        }

        [TestMethod()]
        public void DeleteGameTest()
        {
            //arrange
            GameRepository gr = new GameRepository();

            GameController gc = new GameController(gr);
            //act
            //attempts to delete a game taking id=0
            gc.DeleteGame(1);
            int newGameCount = gc.databasePlaceholder.gameList.Count;

            //assert
            Assert.AreEqual(1, newGameCount);
        }
    }
}
