using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTful_Testful.Models;


namespace RESTful_Testful.Controllers
{
    public class GameController : ApiController
    {
      public GameRepository databasePlaceholder = new GameRepository();
        
        public GameController()
        {
        }

        /// <summary>
        /// created for testing purposes
        /// </summary>
        /// <param name="iGameRepos"></param>
        public GameController(GameRepository gameRepos)
        {
            databasePlaceholder = gameRepos;


        }        

        public IEnumerable<Game> GetAllGames()
        {
            return databasePlaceholder.GetAll();
        }// GetAllGames

        public Game GetGameByID(int id)
        {
            Game game = databasePlaceholder.Get(id);
            if (game == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return game;
        }//end GetGame()

        public HttpResponseMessage PostGame(Game game)
        {
            game = databasePlaceholder.Add(game);
            var response = this.Request.CreateResponse<Game>(HttpStatusCode.Created, game);
            string uri = Url.Link("DefaultApi", new { id = game.ID });
            response.Headers.Location = new Uri(uri);
            return response;
        }//end PostGame()

        public bool PutGame(Game game)
        {
            if (!databasePlaceholder.Update(game))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return true;
        }//end PutGame()

        public void DeleteGame(int id)
        {
            Game game = databasePlaceholder.Get(id);
            if (game == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            databasePlaceholder.Remove(id);
        }//end DeleteGame()
    }
}
