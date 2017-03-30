#Gamer's Dungeon

###Software Architecture Document

Reversion History

Date | Version | Description | Author(s)
----- | ----- | ----- | -----
10/8/2016 | 1.0 | sprint 2 draft | Greg Mattingly, Joseph Olin, Michael Roark
	|||
	|||

#Table Of Contents

1.  Introduction  
	1.1  Purpose  
	1.2  References  
	1.3  Glossary  

2.  Architectural Overview

3.  Architectural Goals and Constraints

4.  Views  
	4.1  Database Schema View  
	4.2  MVC Components View  
	4.3  User / Client Interaction View  
	4.4  RestService View  




#1.  Introduction

**1.1  Purpose**  
* This document serves as a high level architectural overview of the Gamer's Dungeon software system.  
The intent is to provide a comprehensive view of all architectural aspects of the system.

#2.  Architectural Overview  
* This document uses a number of views to model the systems architecture;
it also seeks to describe how these views interact with one another in order to achieve the primary goal of the system.
The views are of the database, the RestService, the MVC website, and the User/Client interaction View.

#3.  Architectural Goals and Constraints  

* Goals
  * The goal of the system is to provide the user with a website on which user can gather information about a particular video game
  * 'Behind the scenes', the system consists of multiple web crawlers that gather information, deposit that information to the database, which in turn the MVC can access the data and display to the user.  
	* (Add more goals as needed)
* Constraints
  * The web pages being 'crawled' are subject to change, therefore, program must constantly check for valid data
  * (Add more constraints as needed)


#4.  Views  
![](https://github.iu.edu/C346/TeamROM/blob/master/github_images/GamersDundeonArchitecture.png)
<br><br>

**4.1  Database Schema View (sample)**  

Database Table Name:  Game Index  

VideoGameName | Price | ReviewRating  
----- | ----- | -----  
Uncharted4 | $3	| 2  
Destiny | $5 | 8  
Overwatch | $7 | 2  
Halo4 | $11 | 6  
Call of Duty Black Ops 3 | $56	| 7  
<br><br>

Database Table Name:  GameInfo  

VideoGameName | Rating | Price | Platform | Vendor  
----- | ----- | ----- | ----- | -----  
Uncharted4 | 2/10 | $3 | PC | Steam  
<br><br>

**4.2  MVC Components**  
* Model
	* This part of MVC corresponds to the objects used in the website.
	* For example, a model class name VideoGAme might exist as a data structure for a video game
* View
	* This corresponds to section 4.3, the actual interface that the user sees
* Controller
	* This part of MVC does much of MVC's processing. 
	* It is essentially a go-between that passes data from the Model to the View, and does any necessary transformations of that data in between.
<br><br>

![](https://github.iu.edu/C346/TeamROM/blob/master/github_images/MVC-architecture.png)


**4.3  User / Client View**  
* The user of this system will access the website via their PC/mobile/etc device.
* Upon arriving at the website, user will navigate to the index of games, where they may choose a particular game to look at.		
<br><br>

**4.4  RestService View**  
* (to be added)
<br><br>




[//]: # (Cool!  This is how we can write a comment, and no, it will not display on github)
