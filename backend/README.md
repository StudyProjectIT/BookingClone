# BookingClone

A hotel booking web application built with ASP.NET Core (backend) and React + Vite (frontend).

## Tech Stack

- **Backend**: ASP.NET Core 10, Entity Framework Core, PostgreSQL, ASP.NET Identity, JWT
- **Frontend**: React, Vite, Axios

## Architecture

The backend follows **Clean Architecture** with 4 projects:

```
backend/
├── Domain/          # Entities, Identity types, repository interfaces, Result/Error. Zero external deps.
│   ├── Entities/        (+ Entities/Identity)
│   ├── EntityInterfaces/
│   ├── Interfaces/      # IHotelRepository, IBookingRepository, IDbInicializer, ...
│   ├── Constants/
│   └── Common/          # Result<T>, Error
├── Application/     # Use cases (services), DTOs, service interfaces. Depends on Domain.
│   ├── DTOs/
│   ├── Interfaces/      # IHotelService, IBookingService
│   ├── Services/        # HotelService, BookingService
│   └── DependencyInjection.cs   # AddApplication()
├── Infrastructure/  # EF Core DbContext, repositories, migrations, DB initializer. Depends on Domain.
│   ├── Data/
│   ├── EntityTypeConfigurations/
│   ├── Repositories/
│   ├── Services/        # DbInitializer
│   ├── Migrations/
│   └── DependencyInjection.cs   # AddInfrastructure(configuration)
└── API/             # Controllers, middleware, composition root. Depends on Application + Infrastructure.
    ├── Controllers/
    ├── Middleware/      # GlobalExceptionHandlingMiddleware
    └── Program.cs
```

Dependency direction (outer depends on inner, never the reverse):
`API → Application → Domain ← Infrastructure`

The frontend follows **Feature-Sliced Design**:

```
frontend/src/
├── app/        # bootstrap, providers, global styles, App.jsx, main.jsx
├── pages/      # route-level screens
├── widgets/    # composite UI blocks
├── features/   # user-facing features
├── entities/   # business entities (hotel, booking, user)
└── shared/     # api/, ui/, lib/, config/, assets/ (no business logic)
```
Path aliases configured in `vite.config.js`: `@`, `@app`, `@pages`, `@widgets`, `@features`, `@entities`, `@shared`.

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
dotnet ef migrations add AddIdentityMigration --project Infrastructure --startup-project API
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

## API endpoints

### Auth (`/api/auth`)
- `POST /api/auth/register` — register a new Customer (returns JWT + user).
- `POST /api/auth/login` — login by email or username (returns JWT + user).
- `GET  /api/auth/me` — current authenticated user (requires `Authorization: Bearer <token>`).

### Hotels (`/api/hotels`)
- `GET  /api/hotels`, `GET /api/hotels/{id}` — public.
- `POST /api/hotels`, `PUT /api/hotels/{id}` — requires role `Admin` or `Realtor`.
- `DELETE /api/hotels/{id}` — requires role `Admin`.

### Bookings (`/api/bookings`)
- All endpoints require authentication (`[Authorize]`).

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
