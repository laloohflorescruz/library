## Library Management System

This is a Library Management System project built using SQLite, Bootstrap, and Entity Framework Core version 7. The system is designed to manage books, authors, and library branch.

This is a project for university.


## Project Features
1. List of book
2. Create and Edit books
3. Details of book 


## Prerequisites
- Visual Studio Code
- .NET Core SDK
- SQLite
- Entity Framework Core 7
- Bootstrap

## Getting Started

### 1. Clone the Repository

git clone https://github.com/laloohflorescruz/library.git
cd LibraryProject

## Tool Required:
-dotnet tool install --global dotnet-ef --version 7.0.0

 
## 1. Run the project
-dotnet run 

### 2. Install Dependencies
dotnet restore
 

### 3. Database Migration
#### 3.1 Install Entity Framework Core Tools

-dotnet tool install --global dotnet-ef --version 7.0.0


#### 3.2 Run Database Migrations

-cd LibraryProject
-dotnet ef migrations add InitialCreate
-dotnet ef database update

### 4. Run the Project

-dotnet run



The application will be accessible at `https://localhost:7243/` by default.

## Project Structure
- **LibraryProject/**
  - **Controllers/** - Contains the controllers for handling HTTP requests.
  - **Models/** - Contains the data models used in the application.
  - **ViewsModel/** - Contains the viewmodel used in the application.
  - **Views/** - Contains the HTML templates and Razor files.
  - **Repo/** - Contains a generic repository with its interface.
  - **wwwroot/** - Contains static files such as CSS, JavaScript, and images.
  - **appsettings.json** - Configuration file for the application.
  - **Startup.cs** - Configures services and the app's request pipeline.



## You can see a live demo here
[Here](https://www.eduardoflores.name/portfolio/LibraryManagement/)


## Demo Pictures

<img src="/LibraryProject/assets/img/01.png"/>
<img src="/LibraryProject/assets/img/02.png"/>
<img src="/LibraryProject/assets/img/03.png"/>
<img src="/LibraryProject/assets/img/04.png"/>
<img src="/LibraryProject/assets/img/05.png"/>
<img src="/LibraryProject/assets/img/06.png"/>
<img src="/LibraryProject/assets/img/07.png"/>
<img src="/LibraryProject/assets/img/08.png"/>
<img src="/LibraryProject/assets/img/09.png"/>
<img src="/LibraryProject/assets/img/10.png"/>
<img src="/LibraryProject/assets/img/11.png"/>
<img src="/LibraryProject/assets/img/12.png"/>
<img src="/LibraryProject/assets/img/13.png"/>


## Contributing
Feel free to contribute to the development of this project by opening issues or pull requests. Your feedback is highly appreciated!

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
 
 