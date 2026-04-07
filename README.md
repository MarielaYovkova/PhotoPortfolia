## PhotoPortfolia 📸

PhotoPortfolia is a web-based application designed for professional photographers to showcase their work, manage digital galleries, and organize their portfolio into meaningful categories.

## Key Features

* **N-Tier Architecture**: Clear separation of concerns between the Presentation Layer (MVC), Business Logic Layer (Services), and Data Access Layer (EF Core).
* **Decoupled Logic**: Controllers are "thin" and communicate with the database only through an abstraction layer (Service Layer) using **Dependency Injection**.
* **Data Security & DTOs**: Implementation of **ViewModels and Data Transfer Objects (DTOs)** to prevent exposing internal Entity models directly to the web pages.
* **Advanced Validation**: Robust server-side and client-side validation with custom error messages to ensure data integrity.
* **Secure Access**: Integrated **ASP.NET Core Identity** to restrict administrative actions (Create, Edit, Delete) only to authenticated users.
* **Responsive Design**: A fully mobile-friendly UI built with Bootstrap 5, ensuring photos look great on any device.

## Technologies Used

* **Backend**: .NET 6.0 / 8.0, ASP.NET Core MVC
* **Data Access**: Entity Framework Core, SQL Server
* **Security**: ASP.NET Core Identity (Authentication & Authorization)
* **Design Patterns**: Service Pattern, Dependency Injection, DTO/ViewModel, MVC
* **Frontend**: Razor Pages, HTML5, CSS3 (Custom Effects & Text Outlines), Bootstrap 5

## 📂 Project Structure

PhotoPortfolia/

├── Controllers/    # Handles HTTP requests and navigation
├── Services/       # Business Logic Layer (IAlbumService)
├── ViewModels/     # Data Transfer Objects (DTOs) for UI
├── Models/         # Entity Framework database models
├── Data/           # DbContext, Identity, and Migrations
└── Views/          # Razor templates and UI logic

## Installation and Setup

To run this project locally, follow these steps:
-Clone the Repository:Bashgit clone https://github.com/MarielaYovkova/PhotoPortfolia.git
-Configure the Database:Open appsettings.json.Update the DefaultConnection string to point to your local SQL Server instance.
-Apply Migrations:Open the Package Manager Console in Visual Studio.Run the command: Update-Database.
-Run the Application:Press F5 or use the command dotnet run to start the web server.

## Environment Variables & Credentials

Connection String: Located in appsettings.json. No external secret keys are required for the local development build.
Authentication: Users must register an account to access management features (Create/Edit/Delete).
Default Configuration: The app is set to run on https://localhost:7xxx by default.

Academic Disclaimer

This project is an original work created for educational purposes. It does not contain code from workshops, demos, or AI-generated logic exceeding the allowed limits.

