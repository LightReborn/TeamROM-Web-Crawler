using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RESTful_Testful.Models
{
    /// <summary>
    /// Represents an individual instance of a Game that is found on an individual website
    /// </summary>
    public class Game
    {
        public int ID { get; set; }
        /// <summary>
        /// The common name of the video game
        /// </summary>
        ///
        public String Name { get; set; }
        /// <summary>
        /// The review rating of the game (if one exists) as provided by Game Informer
        /// </summary>
        [DisplayName("Rating")]
        public double ReviewRating { get; set; }
        /// <summary>
        /// The price of the video game at the specified vendor
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// The specific vendor selling this instance of the game
        /// </summary>
        public String Vendor { get; set; }
        /// <summary>
        /// The url on the vendor's web site where this game can be found
        /// </summary>
        public String ProductUrl { get; set; }
        /// <summary>
        /// The general genre of the video game (i.e. First-Person Shooter)
        /// </summary>
        public String Genre { get; set; }
        /// <summary>
        /// The platform this specific instance of the game runs on (i.e. PC)
        /// </summary>
        public String Platform { get; set; }
    }
}