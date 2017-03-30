using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Model.Models;

namespace WebCrawler.Data.Repos
{
    public interface IGameRepository
    {
        /// <summary>
        /// Queries the total number of games
        /// </summary>
        /// <returns>Total count of games in the database</returns>
        int GetGamesCount();

        /// <summary>
        /// Gets games uniquely identified by Name
        /// </summary>
        /// <returns>Returns games uniquely identified by Name</returns>
        List<Game> GetUniqueGames();

        /// <summary>
        /// Returns empty list if no entity exists with that name
        /// Otherwise, returns all games that correspond to the provided game name
        /// </summary>
        /// <param name="name">The name of a Game</param>
        /// <returns></returns
        List<Game> GetGamesByName(String name);

        /// <summary>
        /// Updates the database with the list of games provided, either updating the games from the list
        /// or adding games to the database from the list
        /// </summary>
        /// <param name="gamesList">The list of games that are compared with the games in the database</param>
        void UpdateGames(IEnumerable<Game> gamesList);
    }
}
