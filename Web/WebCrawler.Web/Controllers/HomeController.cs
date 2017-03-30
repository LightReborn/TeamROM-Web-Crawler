using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebCrawler.Data.Repos;
using WebCrawler.Model.Models;
using System.Runtime.Serialization.Json;

namespace WebCrawler.Web.Controllers
{
    public class HomeController : Controller 
    {

        IGameRepository gameRepo = new WebCrawler.Data.Repos.GameRepository();

        /// <summary>
        /// Default constructor
        /// </summary>
        public HomeController() { }

        /// <summary>
        /// Constructor that allows one to provide an implementation of IGameRepository
        /// </summary>
        /// <param name="gameRepo">A concrete implementation of IGameRepository</param>
        public HomeController(IGameRepository gameRepo)
        {
            this.gameRepo = gameRepo;
        }

        /// <summary>
        /// Landing page for the home page
        /// </summary>
        /// <returns>The rendered landing page of the website</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Index page of video games for the user to browse through and select
        /// </summary>
        /// <returns>The rendered index page of games</returns>
        public ActionResult GamesIndex()
        {
            var games = getGamesFromRESTService();
            gameRepo.UpdateGames(games);
            var gamesToList = gameRepo.GetUniqueGames().OrderByDescending(x=> x.ReviewRating).ToList();
            return View(gamesToList);
        }

        /// <summary>
        /// The description page of a game selected by the user
        /// </summary>
        /// <param name="game">The game selected by the user for viewing</param>
        /// <returns>The rendered description of the game selected by the user</returns>
        public ActionResult ProductPage(WebCrawler.Model.Models.Game game)
        {
            var gameInstances = gameRepo.GetGamesByName(game.Name)
                                        .OrderBy(x=>x.Price).ToList();
            return View(gameInstances);
        }

        /// <summary>
        /// Temporary, practice code
        /// </summary>
        private IEnumerable<Game> getGamesFromRESTService()
        {
            IEnumerable<Game> games = new List<Game>();
            String requestUrl = "http://localhost:51102/api/game";//REST service endpoint
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                    }

                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(IEnumerable<WebCrawler.Model.Models.Game>));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    games = objResponse as IEnumerable<WebCrawler.Model.Models.Game>;

                }
            }
            catch (Exception e)
            {
                // catch exception and log it
                
            }
            return games;
        }


    }
}