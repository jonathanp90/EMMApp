# EMMApp

EMMApp is a small ASP.NET Core web app for collecting and managing registrations for `Encuentro Matrimonial Mundial` weekend events. It serves a public registration form from `wwwroot`, stores submissions in SQLite through Entity Framework Core, and exposes a simple REST API for admin workflows.

## Current Stack

- ASP.NET Core on `.NET 10`
- Entity Framework Core with SQLite
- Static HTML pages in `wwwroot`
- OpenAPI enabled in development

## Project Structure

- `Program.cs` configures the web app, SQLite database connection, CORS, static files, and OpenAPI in development.
- `Controllers/RegistrationsController.cs` exposes CRUD endpoints for registrations.
- `Data/AppDbContext.cs` defines the EF Core database context.
- `Models/Registration.cs` contains the persisted registration model.
- `Dtos/RegistrationCreateDto.cs` defines the create request payload used by the POST endpoint.
- `wwwroot/index.html` is the public registration page.
- `wwwroot/admin.html` is the current admin page prototype.

## Getting Started

### Prerequisites

- `.NET SDK 10.0`

### Run Locally

```bash
dotnet restore
dotnet run
```

By default, the app uses a local SQLite database file:

```text
retreat.db
```

The app serves static frontend files and API endpoints from the same ASP.NET Core host.

## API

Base route:

```text
/api/registrations
```

Available endpoints:

- `GET /api/registrations` returns all registrations ordered by newest first.
- `GET /api/registrations/{id}` returns a single registration by id.
- `POST /api/registrations` creates a registration from the create DTO.
- `PUT /api/registrations/{id}` updates an existing registration.
- `DELETE /api/registrations/{id}` removes a registration.

### Create Payload

Current POST requests accept:

```json
{
  "lastName": "Garcia",
  "hisName": "Jose",
  "herName": "Maria",
  "hisPhone": "555-111-2222",
  "zone": 3,
  "city": "Los Angeles"
}
```

The server currently fills several other fields with default values when a record is created.

## Data Model

Registrations currently store:

- `id`
- `lastName`
- `hisName`
- `herName`
- `city`
- `hisPhone`
- `herPhone`
- `readSpanish`
- `churchMarried`
- `yearsMarried`
- `zone`
- `paid`
- `comments`
- `CreatedAt`

## Frontend Pages

- `/` loads the public registration form from `wwwroot/index.html`
- `/admin.html` loads the admin dashboard prototype

## Development Notes

- OpenAPI is only mapped in development.
- CORS is currently configured with an allow-all policy.
- The project includes generated `bin/` and `obj/` output in the repository; those are build artifacts, not source files.
- The frontend pages are still rough and do not fully match the backend contract yet, so expect some cleanup work before production use.
