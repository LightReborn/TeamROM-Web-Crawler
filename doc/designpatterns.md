#Design Patterns in Gamer's Dungeon

##Repository Pattern
Gamer's Dungeon implements the Repository Pattern, albeit on a relatively minor scale. The MVC site pulls from the GameRepository, which is the MVC's one stop shop for performing CRUD operations on Game data.

##Prototype Pattern
The project also implments the Prototype Pattern. It does this by using an IGameRepository interface for the GameRepository. This allows for multiple implementations of the IGameRepository if such is needed. For example, one instance where such might be used would be to use IGameRepository for both the REST Service and the MVC project. The REST Service would use IGameRepository to perform CRUD operations on game data in JSON files using a certain implementation of IGameRepository. The MVC project, on the other hand, might use IGameRepository with a different concrete implementation to perform CRUD operations on game data using a SQL database.
