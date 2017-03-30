using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Model.Models;
using WebCrawler.Data;
using WebCrawler.Data.DAL;

namespace WebCrawler.Data.Repos
{
    public class GameRepository : IGameRepository
    {

        //private List<Game> games = new List<Game>();
        public List<Game> games = new List<Game>();

        /// <summary>
        /// Context used for querying the Crawler database
        /// </summary>
        // GameContext db;
        public GameContext db;

        /// <summary>
        /// Used temporarily for making fake data
        /// </summary>
        public void generateGameData()
        {
            using (db = new GameContext())
            {
                Random rand = new Random();

                for (int i = 0; i < 20; i++)
                {
                    Game game = new Game();
                    game.ID = i + 1;

                    //Name
                    int rollDice = rand.Next(5);
                    String name;
                    switch (rollDice)
                    {
                        case 0:
                            name = "Halo 4";
                            break;
                        case 1:
                            name = "Uncharted 4";
                            break;
                        case 2:
                            name = "Destiny";
                            break;
                        case 3:
                            name = "Overwatch";
                            break;
                        case 4:
                            name = "Call of Duty Black Ops 3";
                            break;
                        default:
                            name = "";
                            break;
                    }
                    game.Name = name;

                    //Vendor
                    rollDice = rand.Next(5);
                    String vendor;
                    String vendorUrl;
                    switch (rollDice)
                    {
                        case 0:
                            vendor = "GameStop";
                            vendorUrl = "gamestop.com";
                            break;
                        case 1:
                            vendor = "BestBuy";
                            vendorUrl = "bestbuy.com";
                            break;
                        case 2:
                            vendor = "Steam";
                            vendorUrl = "store.steampowered.com";
                            break;
                        case 3:
                            vendor = "WalMart";
                            vendorUrl = "walmart.com";
                            break;
                        case 4:
                            vendor = "Target";
                            vendorUrl = "target.com";
                            break;
                        default:
                            vendor = "";
                            vendorUrl = "";
                            break;
                    }
                    game.Vendor = vendor;
                    game.ProductUrl = "http://" + vendorUrl;
                    //Platform
                    rollDice = rand.Next(4);
                    String platform;
                    switch (rollDice)
                    {
                        case 0:
                            platform = "PC";
                            break;
                        case 1:
                            platform = "PS4";
                            break;
                        case 2:
                            platform = "Xbox One";
                            break;
                        case 3:
                            platform = "Wii U";
                            break;
                        default:
                            platform = "";
                            break;
                    }
                    game.Platform = platform;

                    //Review rating
                    double rating = ((int)(100 * rand.NextDouble() * 10)) / 100;
                    game.ReviewRating = rating;
                    //Price
                    double price = ((int)(100 * rand.NextDouble() * 60)) / 100;
                    game.Price = price;

                    games.Add(game);
                    db.Games.Add(game);

                }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Used temporarily for making fake data
        /// </summary>
        public void generateFakeGameData()
        {
            using (db = new GameContext())
            {
                //Random rand = new Random();

                for (int i = 0; i < 5; i++)
                {
                    Game game = new Game();
                    game.ID = i + 1;

                    //Name
                   // int rollDice = rand.Next(5);
                    int rollDice = i;
                    String name;
                    switch (rollDice)
                    {
                        case 0:
                            name = "Halo 4";
                            break;
                        case 1:
                            name = "Uncharted 4";
                            break;
                        case 2:
                            name = "Destiny";
                            break;
                        case 3:
                            name = "Overwatch";
                            break;
                        case 4:
                            name = "Call of Duty Black Ops 3";
                            break;
                        default:
                            name = "";
                            break;
                    }
                    game.Name = name;

                    //Vendor
                   // rollDice = rand.Next(5);
                    rollDice = i;
                    String vendor;
                    String vendorUrl;
                    switch (rollDice)
                    {
                        case 0:
                            vendor = "GameStop";
                            vendorUrl = "gamestop.com";
                            break;
                        case 1:
                            vendor = "BestBuy";
                            vendorUrl = "bestbuy.com";
                            break;
                        case 2:
                            vendor = "Steam";
                            vendorUrl = "store.steampowered.com";
                            break;
                        case 3:
                            vendor = "WalMart";
                            vendorUrl = "walmart.com";
                            break;
                        case 4:
                            vendor = "Target";
                            vendorUrl = "target.com";
                            break;
                        default:
                            vendor = "";
                            vendorUrl = "";
                            break;
                    }
                    game.Vendor = vendor;
                    game.ProductUrl = "http://" + vendorUrl;
                    //Platform
                   // rollDice = rand.Next(4);
                    rollDice = i;
                    String platform;
                    switch (rollDice)
                    {
                        case 0:
                            platform = "PC";
                            break;
                        case 1:
                            platform = "PS4";
                            break;
                        case 2:
                            platform = "Xbox One";
                            break;
                        case 3:
                            platform = "Wii U";
                            break;
                        default:
                            platform = "";
                            break;
                    }
                    game.Platform = platform;

                    //Review rating
                   // double rating = ((int)(100 * rand.NextDouble() * 10)) / 100;
                    double rating = ((int)(100 * i * 10)) / 100;
                    game.ReviewRating = rating;
                    //Price
                 //   double price = ((int)(100 * rand.NextDouble() * 60)) / 100;
                    double price = ((int)(100 * i * 60)) / 100;
                    game.Price = price;

                    games.Add(game);
                    db.Games.Add(game);

                }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Queries the total number of games
        /// </summary>
        /// <returns>Total count of games in the database</returns>
        public int GetGamesCount()
        {
            int numGames = 0;
            using (db = new GameContext())
            {
                 numGames = db.Games.Count();
                
            }
            return numGames;
        }

        /// <summary>
        /// Gets a count of games uniquely identified by Name
        /// </summary>
        /// <returns>Returns count of games uniquely identified by Name</returns>
        public int GetUniqueGamesCount()
        {
            int uniqueNumGames = 0;
            using(db = new GameContext())
            {

                var distinctGames = db.Games.GroupBy(x => x.Name)
                                     .Select(x => x)
                                     .ToList()
                                     .Distinct();
                uniqueNumGames = distinctGames.Count();
            }
            return uniqueNumGames;
        }

        /// <summary>
        /// Gets games uniquely identified by Name
        /// </summary>
        /// <returns>Returns games uniquely identified by Name</returns>
        public List<Game> GetUniqueGames()
        {
            var uniqueGames = new List<Game>();
            using(db = new GameContext())
            {
                var distinctGames = db.Games.OrderBy(x => x.Price)
                                     .GroupBy(x => x.Name)
                                     .Select(x => x)
                                     .ToList()
                                     .Distinct();
                                    
                uniqueGames = distinctGames.Select(x => x.ElementAt(0)).ToList();
            }
                
            return uniqueGames;
           
        }

        /// <summary>
        /// Returns empty list if no entity exists with that name
        /// Otherwise, returns all games that correspond to the provided game name
        /// </summary>
        /// <param name="name">The name of a Game</param>
        /// <returns></returns>
        public List<Game> GetGamesByName(String name)
        {
            var distinctGames = new List<Game>();
            using(db = new GameContext())
            {
                distinctGames = db.Games.Where(x => x.Name.ToLower().Equals(name.ToLower()))
                                                     .Select(x => x)
                                                     .ToList();
            }
            return distinctGames;
        }

        /// <summary>
        /// Updates the database with the list of games provided, either updating the games from the list
        /// or adding games to the database from the list
        /// </summary>
        /// <param name="gamesList">The list of games that are compared with the games in the database</param>
        public void UpdateGames(IEnumerable<Game> gamesList)
        {
            using(db = new GameContext())
            {
                foreach(var game in gamesList)
                {
                    var gameFromDb = db.Games.SingleOrDefault(x => x.ID == game.ID);

                    if (gameFromDb != null)
                    {
                        gameFromDb.Price = game.Price;
                        gameFromDb.ReviewRating = game.ReviewRating;
                        gameFromDb.Genre = game.Genre;
                        gameFromDb.Platform = game.Platform ?? "N/A";
                        gameFromDb.ProductUrl = game.ProductUrl ?? "http://gamestop.com";
                        gameFromDb.Vendor = game.Vendor ?? "Gamestop";
                        gameFromDb.Name = game.Name ?? "N/A";
                    }
                    else
                    {
                        gameFromDb = game;
                        gameFromDb.Platform = gameFromDb.Platform ?? "empty";
                        gameFromDb.ProductUrl = gameFromDb.ProductUrl ?? "http://gamestop.com";
                        gameFromDb.Vendor = gameFromDb.Vendor ?? "Gamestop";
                        gameFromDb.Name = gameFromDb.Name ?? "empty";
                        db.Games.Add(gameFromDb);
                    }
                    db.SaveChanges();
                }
            }
        }      
    }
}
