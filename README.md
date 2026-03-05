PhotoPortfolia 📸

PhotoPortfolia is a web-based application designed for professional photographers to showcase their work, manage digital galleries, and organize their portfolio into meaningful categories.

Key Features

Album Management: Full CRUD operations for creating, viewing, updating, and deleting photography albums.
Categorization: Organize photography work into specific genres like Portraits, Weddings, or Landscapes.
Responsive Design: A fully mobile-friendly UI built with Bootstrap to ensure photos look great on any device.
Data Validation: Robust server-side and client-side validation for all user inputs.
Clean Architecture: Built using the MVC (Model-View-Controller) pattern and SOLID principles.

Technologies Used

Framework:ASP.NET Core (.NET 6.0+)
Database: Microsoft SQL Server 
ORM: Entity Framework Core 
Frontend: Razor Pages, HTML5, CSS3, and Bootstrap 
Design Patterns: Dependency Injection and MVC

Installation and Setup

To run this project locally, follow these steps:Clone the Repository:Bashgit clone https://github.com/YourUsername/PhotoPortfolia.git
Configure the Database:Open appsettings.json.Update the DefaultConnection string to point to your local SQL Server instance.
Apply Migrations:Open the Package Manager Console in Visual Studio.Run the command: Update-Database.
Run the Application:Press F5 or use the command dotnet run to start the web server.

Environment Variables & Credentials

Connection String: Located in appsettings.json. No external secret keys are required for the local development build.
Default Configuration: The app is set to run on https://localhost:7xxx by default.

Academic Disclaimer

This project is an original work created for educational purposes. It does not contain code from workshops, demos, or AI-generated logic exceeding the allowed limits.
