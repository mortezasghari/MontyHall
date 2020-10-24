# Monty Hall Problem
The Monty Hall is a brain teaser, in the form of a probability puzzle, loosely based on the American television game show Let's Make a Deal and named after its original host, Monty Hall. The concept of the game is that the player sees three closed doors behind one is a car, and behind the other two are goats. The game starts with the player getting to choose a door, without opening it. Then the presenter opens one of the two remaining doors (but never the one with the car) and shows that this door does not contain profit. The player is then given another choice to change the door. The question is whether the chances of winning increase if the player changes the door. [source](https://en.wikipedia.org/wiki/Monty_Hall_problem)

_This application will try to use simulation to prove the paradox._

## Solution structure
This solution is implemented in 6 projects.
### MontyHallLibrary
This project is the Library for "Monty Hall Game". 
### MontyHallService
This Project includes a simulation that tries to prove the paradox. should you change the box or not. 
### MontyHallTest
Unit tests for the whole solution exist in this project. 
### MontyHallWeb.Server 
You can access the simulation via rest API using this project. there is a section in the "appsetting.json" file, with the name "GameSetting", you can configure the Game using these settings. 
1. "Boxes": the number of boxes, 
1. "Helps": the number of helps you can ask. (simulation will take all the help it gets.)
1. "Prizes": is a list of prizes. (The Game can differentiate between prizes, but for the simulation, we only check if you have won something.)
 
Every combination of these setting can't result in an actual game:
- Number of boxes should be at least 3
- Number of Helps should be at least 1
- Number of Prizes should be at least 1
- Number of boxes should be bigger than the number of prizes + number of helps. 
### MontyHallWeb.Client 
It's the client project which is using Blazor WebAssembly to provide access and show the result of the simulation. On the main page, there is a 2 option. one number of simulations and the other a checkbox. if the checkbox is selected simulation will change its mind whenever giving the change. if it is not selected the simulation won't change the box which has been selected. 
### MontyHallWeb.Shared
DTOs are shared with the server and client. 

## Running it.
You should have the latest version of dotnet core installed on your computer. 
### Visual Studio
1. clone the repo 
1. Open the solution in Visual Studio 2019
1. Make sure "MontyHallWeb.Server" is selected as the startup project.
1. Run it.

### Using dotnet core CLI (on windows)
```
git clone https://github.com/mortezasghari/MontyHall.git
cd .\MontyHall\
dotnet build .\MontyHall.sln
cd .\MontyHallWeb\Server\
dotnet run .\MontyHallWeb.Server.csproj
```
Now can access it using the link "http://localhost:5000/"
