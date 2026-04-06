# Zest API - Clean Architecture (.NET)

## Overview

Zest API is a backend service built using **ASP.NET Core Web API** following **Clean Architecture principles**.
The project is structured to ensure **separation of concerns**, **testability**, and **scalability**.

---
## Demo
 In the root directory click on Demo.mp4 and then the vidio get downloade after clicked on the row view then take 
 a look on the demo. 

## Architecture

We are following **Clean Architecture (Layered Architecture)**.

### Layers

```
UI (Presentation Layer)
    ↓
Application (Use Cases / Business Logic)
    ↓
Domain (Core Business Models & Contracts)
    ↓
Infrastructure (External Implementations)
```

---

## Project Structure

```text
Zest_india_assignment
│
├── Zest.Domain
│   ├── Entities
│   │   ├── Student.cs
│   │   └── User.cs
│   ├── Interfaces
│   │   ├── IStudentRepository.cs
│   │   ├── IAuthRepository.cs
│   │   └── IUnitOfWork.cs
│   └── Common
│
├── Zest.Application
│   ├── Commons
│   │   └── Constants
│   │       └── Constants.cs
│   │
│   ├── DTOs
│   │   ├── Auth
│   │   │   ├── LoginRequestDto.cs
│   │   │   ├── LoginResponseDto.cs
│   │   │   ├── RegisterRequestDto.cs
│   │   │   └── RegisterResponseDto.cs
│   │   │
│   │   ├── Student
│   │   │   ├── CreateStudentRequestDto.cs
│   │   │   ├── UpdateStudentRequestDto.cs
│   │   │   └── StudentResponseDto.cs
│   │   │
│   │   └── ApiResponseDto.cs
│   │
│   ├── Interfaces
│   │   ├── IAuthService.cs
│   │   └── IStudentService.cs
│
├── Zest.Infrastructure
│   ├── Data
│   │   └── ApplicationDbContext.cs
│   │
│   ├── Persistence
│   │   ├── Repositories
│   │   │   ├── StudentRepository.cs
│   │   │   └── AuthRepository.cs
│   │   └── UnitOfWork.cs
│   │
│   ├── Services
│   │   ├── StudentService.cs
│   │   └── AuthService.cs
│   │
│   ├── DependencyInjection
│   │   └── DependencyInjection.cs
│
├── Zest.UI
│   ├── Controllers
│   │   ├── AuthController.cs
│   │   └── StudentController.cs
│   │
│   ├── Middlewares
│   │   └── ExceptionMiddleware.cs
│   │
│   ├── Program.cs
│   └── appsettings.json
```

---

## Layer Responsibilities

### Domain

* Entities (e.g., Student, User)
* Repository Interfaces
* No external dependencies

---

### Application

* DTOs (Request/Response)
* Service Interfaces
* Business use cases

---

### Infrastructure

* Database (EF Core)
* Repository Implementations
* External Services (JWT, Email, etc.)
* Dependency Injection setup

---

### UI (API Layer)

* Controllers
* Middleware (Exception Handling)
* Authentication (JWT)
* Request handling

---

## Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* Serilog (Logging)
* BCrypt (Password Hashing)

---

## Setup Instructions

### 1. Clone Repository

```
git clone https://github.com/Sominath1212/Zest_india_assignment
cd Zest_india_assignment
```

---

### 2. Install Dependencies

```
dotnet restore
```

---

### 3. Configure Database

Update `appsettings.json`:

```
 "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ZestDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
 },
 
     "Jwt": {
         "Key": "thisissosecuresecretkeyYourSuperSecretKey123456789",
         "Issuer": "ZestAPI",
         "Audience": "ZestClient",
         "ExpiryMinutes": 60
     }
```

---

### 4. Run Migrations

```
dotnet ef migrations add InitialCreate -p Zest.Infrastructure -s Zest.UI
dotnet ef database update -p Zest.Infrastructure -s Zest.UI
```

---

### 5. Run Project

```
dotnet run --project Zest.UI
```

---

## Authentication (JWT)

* Token-based authentication implemented
* Login/Register returns JWT token
* Protected routes use `[Authorize]`

### Flow

```
Login/Register → Generate Token → Send Token in Header

Authorization: Bearer <token>
```

---

## Logging

* Implemented using **Serilog**
* Logs stored in:

  * Console
  * File (`/logs` directory)

---

## Global Exception Handling

* Custom middleware handles all exceptions
* Returns structured JSON response
* Logs errors centrally

---

## API Response Format

All APIs return standardized response:

```
{
  "statusCode": 200,
  "message": "Success",
  "data": [...]
}
```

---

## CRUD Features

### Student Module

* Create Student
* Get All Students
* Get Student by ID
* Update (PATCH - Partial Update)
* Delete Student

---

## Key Design Decisions

* DTOs used instead of exposing Entities
* Repository Pattern for data access
* Unit of Work for transaction handling
* Service Layer for business logic
* Clean separation between layers

---

## Important Notes

* PATCH uses **nullable DTOs** for partial updates
* Validation handled via DataAnnotations
* Passwords are hashed using BCrypt
* JWT validation handled by framework middleware

---


---

## Run Summary

```
Restore → Configure DB → Run Migration → Start API
```
