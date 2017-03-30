#Proposal#
**Team Members**
* Greg Mattingly
* Joseph Olin
* Michael Roark

We plan to create a web crawler that scrapes video game data (prices, reviews, pictures, etc.) from external web sites, and then presents that video game data as an MVC dashboard website to the user. This dashboard will allow the user to view, make decisions upon, and navigate to the video game data. By creating this dashboard, it is our goal that users will not need to surf multiple web sites to find information about one or more video games. Rather, they will have a wealth of information about each particular game easily accessible in one place.

The general premise of this project is that the web crawler will scrape many different video game vendors for prices and game information (such as the game cover and genre). The web crawler will then make this data available to the web project, either via a SQL database or a REST service. Using this data, the web project will display a tabulated list of video games, with basic name, price, and review information in each row. Then, the page for each individual game will have a picture of the game, a list of vendors selling the game and the price they are selling it at, and the review rating of the game. Once deciding upon a game, the user will be able to navigate directly from our website to the vendor of their choosing for the game of their choosing.

##Features##
* Lists a number of video games for the user view and interact with
* Aggregates prices for each individual game in one place
* Grabs the popular review(s) for each individual game 
* Enables the user to navigate to an external site to purchase a game via clickable listings

