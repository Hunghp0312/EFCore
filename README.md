﻿# EFCore
## Assignment1
## Project Structure
- `Controllers/`: Contains API controllers for handling HTTP requests.
- `Data/`: Includes the database context and related configurations.
- `Entity/`: Defines the domain models (entities).
- `Migrations/`: Stores EF Core migration files.
- `Properties/`: Contains project metadata.
- `appsettings.json`: Configuration file for application settings.
- `Program.cs`: Entry point of the application.

## Assignment2
- Run migration with: dotnet ef migrations add InitalCreate --project DAL --startup-project Assignemnt2.
- Run db update: dotnet ef database update --project DAL --startup-project Assignemnt2.
- Using transaction in DeleteAll in Repository Base.
