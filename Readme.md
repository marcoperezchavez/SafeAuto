# Project SafeAuto Web application with Angular version 11 and Web Api .Net Core 5 and SQL Server DB with EF Core and Migrations

***
Description: Select a file (is in this project and example in filesExamples folder, "SafeAuto.txt") if the row to the file has the correct  format will be added in DB and then will be showed in the DB.

## Intructions to install 
* 1- clone the repository in your local machine

### Configuration BE project (Web Api and DB)
* 2- Open BEApi.sln project in Visual Studio
  * 2.1 BEApi folder and open in an text editor "appsettings" file.
  * 2.2 Update the "Default connection with your DB connection" for example : "DefaultConnection": "Data Source=localhost\\SQLEXPRESS;Database=SafeAutoDB;Trusted_Connection=True;MultipleActiveResultSets=true" Save the file when tou update the DBConnection
  * 2.3 In visual,  Go to Tools > NuGet Package Manager > Package Manager Console and write the next command ---     Update-Database   ----  Whith this command you will create the database and tables
  * 2.4 Update the localhost to https://localhost:44365/ only if that is different
  * 2.5 Run the project

### Configuration FE project (Angular)
* 3- Open the folder FE in Visual Studio Code
  * 3.1 run the application with the command ---     ng serve --o       -----  this command run the application in local machine

### Result application
![image](https://user-images.githubusercontent.com/15023112/110024158-a5790100-7cf3-11eb-8db7-1ccb2c24dd59.png)


### Functionality 
* 4- Click in Search Button and select the file "SafeAuto.txt" that is attached in this project in the "filesExamples" folder

### You have some results similar of this

![image](https://user-images.githubusercontent.com/15023112/110024829-351eaf80-7cf4-11eb-9dcc-5829c21ebbc1.png)

@By Marco Perez
