using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTful_Testful.Models
{
    public class GameRepository : IGameRepository
    {
        public List<Game> gameList = new List<Game>();
        public int databaseId = 1;

        public GameRepository()
        {
            // For the moment, we will load some sample data during initialization.
            //not including vendor, url, etc right now.
            this.Add(new Game { Name = "Halo 3", Price = 19.99, ReviewRating = 10.0, ID = 2});
            this.Add(new Game { Name = "Half Life 2", Price = 29.99, ReviewRating = 9.8, ID = 3 });
        }//end constructor

        public IEnumerable<Game> GetAll()
        {
            return gameList;
        }//end GetAll

        public Game Get(int id)
        {
            return gameList.Find(p => p.ID == id);
        }//ende Get

        public Game Add(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException("game");
            }
            game.ID = databaseId++;
            gameList.Add(game);
            return game;
        }// end Add

        public void Remove(int id)
        {
            gameList.RemoveAll(p => p.ID == id);
        }//end Remove

        public bool Update(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException("game");
            }
            int index = gameList.FindIndex(p => p.ID == game.ID);
            if (index == -1)
            {
                return false;//the ID provided was not found, send false to let program know.
            }
            gameList.RemoveAt(index);
            gameList.Add(game);

            return true;//found and replaced the Game object. return true to let program know.
        }//end Update
    }
}