# wp-gaming

**ConnectFourService**

I have seperated out the core ConnectFour algorithm in to a seperate project . The idea here is to seperate this one out from front-end. This way we can implement any front end(console app, windows or Web) on top of it and more importantly **ConnectFourService** can be fully testable.


**ConnectFourGameTest**

project contains all test methods to test **ConnectFourService** algorithm.


**ConnectFourConsoleApp**

I have used front end as console APP. This project contains ConnectFourConsole class to handle all user interaction through command line.  

**Technologies Used**
1. .NET Core Console App using **.NET Core 2.1**


**Execution Instructions - Console App**
1. Open WPGaming.sln using Visual Sutdio
2. ConnectFourConsoleApp should have set as start up project. If not, please set this as start up project.
3. Rebuild and Run the soution.


**Execution Instructions - Tests**
1. Open WPGaming.sln using Visual Sutdio
2. Locate ConnectFourGameTest project and open ConnectFourTest.cs file
3. Open Test Explorer and run tests.
