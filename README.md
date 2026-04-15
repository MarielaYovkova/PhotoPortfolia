PhotoPortfolia 📸
PhotoPortfolia is a professional web-based gallery platform built with ASP.NET Core, designed for photographers to showcase their work, manage digital albums, and engage with their audience through a structured and secure interface.

Key Features
N-Tier Architecture: Clear separation of concerns between the Presentation Layer (MVC), Business Logic Layer (Services), and Data Access Layer (EF Core).

Decoupled Business Logic: Implementation of the Service Pattern and Dependency Injection to keep controllers "thin" and maintainable.

Administrative Area: Dedicated MVC Area for category management, accessible only to authorized administrators.

Unit Testing: High code quality ensured by xUnit tests covering over 65% of the business logic, using Moq and EF Core In-Memory database.

Data Security: Use of ViewModels and DTOs to prevent sensitive data exposure and ensure strict validation.

User Engagement: Integrated Partial Views for a dynamic commenting system under each album.

Error Handling: Custom-designed 404 (Not Found) and 500 (Server Error) pages for a seamless user experience.

Responsive UI: Mobile-friendly design built with Bootstrap 5 and custom CSS effects.

Technologies Used
Backend: .NET 8.0, ASP.NET Core MVC

Data Access: Entity Framework Core, SQL Server

Security: ASP.NET Core Identity (Roles: Administrator, User)

Testing: xUnit, Moq, Fluent Assertions

Design Patterns: Service Pattern, Repository-like Data Access, DTO/ViewModel, MVC

Frontend: Razor Views, HTML5, CSS3, Bootstrap 5

Project Structure
Plaintext
PhotoPortfolia/
├── Areas/Admin/      # Administrative management logic (Categories)
├── Controllers/      # HTTP request handling
├── Services/         # Business Logic Layer (Interfaces & Implementations)
├── ViewModels/       # Data Transfer Objects for the UI layer
├── Models/           # Database entities (EF Core models)
├── Data/             # DbContext, Identity configuration, and Migrations
├── Views/            # Razor templates (including Partial Views)
└── PhotoPortfolia.Tests/ # xUnit test project
Installation and Setup
Clone the Repository:

Bash
git clone https://github.com/MarielaYovkova/PhotoPortfolia.git
Configure the Database:
Update the DefaultConnection string in appsettings.json to point to your local SQL Server instance.

Apply Migrations:
In the Package Manager Console, run:

PowerShell
Update-Database
Run Tests:
Open Test Explorer in Visual Studio and click Run All to verify the 11 unit tests.

Start the App:
Press F5 or use dotnet run.

Testing Coverage
The project includes comprehensive unit tests for:

CategoryService: CRUD operations and edge cases.

CommentService: Security logic and permission checks.

AlbumService: Search filtering and detailed data retrieval.

🎓 Academic Disclaimer

This project is an original work created for educational purposes. It does not contain code from workshops, demos, or AI-generated logic exceeding the allowed limits.
