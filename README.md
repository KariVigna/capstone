# _Task-olotl_

### By _**Kari Vigna**_

### _An MVC C# application to track and reward chores for Children and their Families_

## Technologies Used

* C#
* .NET 6Razor HTML
* CSS
* MySQL
* Visual Studio Code
* Git/Github

## Description
Task-olotl gives children and families a fun way to incentivize chore divying by earing stars and getting rewarded. Caregivers can assign tasks to different kids, decide how many stars they will earn, and offer a list of prizes for the child to redeem with their stars.

## Set Up/Installation Requirements

Install the `dotnet-ef` tool by running the following command in your terminal:

```
dotnet tool install --global dotnet-ef --version 6.0.0
```

### Set Up and Run Project
1. Clone this repo.
2. Open the terminal and navigate to this project's main directory called "Capstone.Solution".
3. Within the production directory "Capstone", create new file: `appsettings.json`.
4. Within `appsettings.json`, put in the following code. Make sure to replace the `uid` and `pwd` values in the MySQL database connection string with your own username and password for MySQL. 

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=gh-user;uid=[YOUR_USERNAME];pwd=[YOUR_MYSQL_PASSWORD];"
  }
}
```
5. Install all necessary packages by running `dotnet restore` in the shell while within the production directory "Capstone".
6. Create the database using the migrations in the Capstone project. Open your shell (e.g., Terminal or GitBash) to the production directory "Capstone", and run `dotnet ef database update`. 
7. Within the production directory "Capstone", run `dotnet watch run` in the command line to start the project server and open the webpage within your browser. 
9. The Client side program will use the domain _http://localhost:5001_. 


## Known Bugs

* _Cannot delete "join" relationship between Prize and Kid_
* _"Completed Tasks" view broken_


## License

MIT License
Copyright (c) Kari Vigna 2024

### Research & Planning Log

#### Log
    1/27/24
    * 1:58pm - Researching possibility of using godot to create a game instead of original productivity app idea. Watching Godot tutorials on youtube.
    * 3:08pm - following along with godot tutorial from freecodecamp.
    * 3:50 - break.
    *8:41pm - picking back up on tutorial
    * 10:51pm - worked partially through godot tutorial.
    
    1/28/24
    * 8:00am - picking back op on tutorial
    * 8:50am - working on player animation
    
    1/29/24
    * 5:00pm - I got my character to land on a platform! Feeling like this idea might work out
    
    2/03/24
    *6:00am - trashing game idea, constructing and configuring MVC .NET app.
    *6:34am - Models will be: Item, List, Priority.. Items can belong to one list, each item has one Priority level.
    *8:00am - App file structure in place, running into a server error.
    *7:40pm - Fixed the server error, finished setting up models and index controllers for each, made my first migration

    2/04/24
    *10:00am - thinking "out loud". Tasks will belong to TaskType and Days. Days can have many tasks. Task types can have many tasks. Days will not have task types, task types will not belong to days.
    *4:40pm - spent most of the day building this, trying to understand each part (again), also trying to make it different from to-do-list practice project.

    2/11/24
    *