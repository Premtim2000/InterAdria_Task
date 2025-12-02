# Product Management API

This is a .NET 8 Web API project for managing products, built using ASP.NET Core and Entity Framework Core. The application supports CRUD operations for products, JWT authentication, and automatically creates a local SQL Server database on first run.

---

## Features

- **Product Entity** with fields: Id, Name, Category, Price, StockQuantity, CreatedAt
- **CRUD Endpoints** for products
- **Filtering** by category, minPrice, maxPrice
- **JWT Authentication**
- **Service Layer** implementing business logic
- **DTOs** using CQRS pattern
- **Database** using SQL Server LocalDB (created automatically)

---

## How to use


- Clone the Repository.
- Start the project.
- When the project is started, a local db will be created in SQL Server, and a user with admin(username) and admin(password) will be created automatically.
- To be able to connect to the db, open SSMS (SQL server management studio), add '(localdb)\\MSSQLLocalDB' to the server name, and make the authentication as Windows authentication.
