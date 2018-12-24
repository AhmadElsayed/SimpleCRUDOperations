# Simple CRUD Operations
A simple application to Add, Update, and Delete data from a many to many related tables using ASP.Net MVC, Bootstrap, AngularJS, EF Code First, and Web APIs.

## The sample description



## Code Structure
For simplicity, I have created one project containing all the areas of the code and used Folders to structure my files

### Entities Structure
The two tables structures are as follows

#### Student
* **ID:** int
* **Number:** String
* **FirstName:** String
* **MidName:** String
* **LastName:** String
* **Birthdate:** SateTime
#### Subject
* **ID:** int
* **Name:** String
* **Code:** String

The complete implementation can be found on the Student & Subject files with the context configuration for the Code First entities

![Entities](https://resources20181224092608.azurewebsites.net/images/entities.png)

### Web APIs
The default API controllers for the both entities are created by default based on the created entities with some edits specifically for including Subjects list with student and referring the existing subjects while adding or editing students entity. Controllers are added to the Controllers folders side by side with the existing controller "HomeController".

### Client Side Code
Primarily two files created, one of them can be considered a Utility class for the Student independent of any other components which is Student. The other one is the AngularJS Home controller for the SPA.

![Entities](https://resources20181224092608.azurewebsites.net/images/angular.png)

![Entities](https://resources20181224092608.azurewebsites.net/images/student.png)

![Entities](https://resources20181224092608.azurewebsites.net/images/AngularController.png)

