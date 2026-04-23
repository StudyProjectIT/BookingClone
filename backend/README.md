# BookingClone

A hotel booking web application built with ASP.NET Core (backend) and React + Vite (frontend).

## Tech Stack

- **Backend**: ASP.NET Core 10, Entity Framework Core, PostgreSQL, ASP.NET Identity, JWT
- **Frontend**: React, Vite, Axios

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js 20+](https://nodejs.org/)
- [PostgreSQL](https://www.postgresql.org/)

## Setup

### 1. Configure secrets (each developer does this once)

```bash
cd backend/API
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=bookingclone;Username=postgres;Password=yourpassword"
dotnet user-secrets set "Jwt:Key" "super-secret-key-minimum-32-characters!!"
```

### 2. Apply database migrations

```bash
cd backend
dotnet ef database update --project Infrastructure --startup-project API
```

### 3. Run the backend

```bash
cd backend/API
dotnet run
```

API will be available at `http://localhost:5134`, HTTPS `https://localhost:7131`. 
Swagger UI at `http://localhost:5134/swagger`.

### 4. Run the frontend

```bash
cd frontend
npm install
npm run dev
```

Frontend will be available at `http://localhost:5173`.

## Team workflow for database migrations

1. One developer modifies an entity and creates a migration:
   ```bash
   cd backend
   dotnet ef migrations add <MigrationName> --project Infrastructure --startup-project API
   ```
2. Commit the generated migration files.
3. Other team members apply the migration after `git pull`:
   ```bash
   dotnet ef database update --project Infrastructure --startup-project API
   ```
