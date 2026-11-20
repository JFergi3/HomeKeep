
# HomeKeep

### Home Maintenance Tracking Application

HomeKeep is an ASP.NET Core MVC application designed to help homeowners organize recurring maintenance tasks and keep a record of completed work.

The application provides a centralized place to track household maintenance, review task details, and document maintenance history.

**Live Application:** [HomeKeep on Azure](YOUR-AZURE-URL)

## Project Overview

HomeKeep helps homeowners stay organized by providing:

- A list of recurring household maintenance tasks.
- Detailed task descriptions and maintenance schedules.
- Maintenance history for completed work.
- User authentication and role-based permissions.
- A REST API for accessing and managing maintenance tasks.

## Technologies Used

- C# and ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- Razor Views
- Bootstrap
- REST API controllers and minimal APIs
- Microsoft Azure
- Git and GitHub

## Application Features

### Maintenance Tasks

Visitors can browse maintenance tasks and view their details.

Each task includes information such as its name, description, room, maintenance frequency, completion status, and optional notes.

### Maintenance History

Registered users can record maintenance activity and review previous work associated with a task.

Maintenance logs include a completion date, the person who performed the work, and notes about the activity.

### Authentication and Authorization

HomeKeep uses ASP.NET Core Identity for authentication and role-based authorization.

**Visitors**
- View maintenance tasks and details without signing in.

**Registered Users**
- Sign in and record maintenance activity.
- Review maintenance history.

**Managers**
- Create, edit, and delete maintenance tasks.
- Access Manager-protected API write operations.

The Manager role is assigned through the application's role seeding configuration.

## REST API

HomeKeep provides JSON endpoints alongside its existing MVC pages.

The API allows external applications to retrieve maintenance information and authorized Managers to create or delete maintenance tasks.

### API Endpoints

| Method | Endpoint | Description | Access |
|---|---|---|---|
| GET | `/api/MaintenanceTasks` | Retrieve all maintenance tasks | Public |
| GET | `/api/MaintenanceTasks/{id}` | Retrieve one task with its maintenance logs | Public |
| GET | `/api/MaintenanceTasks/count` | Retrieve the total number of tasks | Public |
| POST | `/api/MaintenanceTasks` | Create a maintenance task | Manager |
| DELETE | `/api/MaintenanceTasks/{id}` | Delete a maintenance task | Manager |

### Data Transfer Objects (DTOs)

The API uses DTOs to control the information sent and received.

- `MaintenanceTaskDto` — maintenance task list data.
- `MaintenanceTaskDetailsDto` — individual task with related maintenance logs.
- `MaintenanceLogDto` — maintenance history information.
- `MaintenanceTaskInput` — validated input for creating tasks.

DTOs prevent circular references between related Entity Framework Core models and limit the properties exposed through the API.

### Example GET Request

```http
GET /api/MaintenanceTasks/1
```

The response contains the maintenance task and its associated `maintenanceLogs` collection.

### Example POST Request

```http
POST /api/MaintenanceTasks
Content-Type: application/json
```

```json
{
  "name": "Replace HVAC Filter",
  "description": "Replace the furnace filter to maintain airflow.",
  "room": "Basement",
  "frequencyDays": 90,
  "isCompleted": false,
  "maintenanceNotes": "Use the correct filter size."
}
```

A successful POST returns `201 Created` with a Location header identifying the new resource.

### API Response Codes

| Status | Meaning |
|---|---|
| 200 OK | Request completed successfully |
| 201 Created | Maintenance task created |
| 204 No Content | Maintenance task deleted |
| 400 Bad Request | Invalid input |
| 401 Unauthorized | Authentication required |
| 403 Forbidden | User lacks the Manager role |
| 404 Not Found | Requested record does not exist |

API errors return HTTP responses without the MVC Missing page HTML.

### API Testing

An API testing interface is available at:

`/api-tester.html`

The API can also be tested using a browser, Postman, or another HTTP client.

## Running HomeKeep Locally

### Prerequisites

- .NET SDK compatible with the project
- SQL Server or SQL Server LocalDB
- Visual Studio or Visual Studio Code
- Git

### Setup

1. Clone the repository.

```bash
git clone YOUR-GITHUB-REPOSITORY-URL
```

2. Navigate to the application directory.

```bash
cd HomeKeep
```

3. Configure the SQL Server connection string using the appropriate local development settings.

4. Configure the Manager email using .NET user secrets.

```powershell
dotnet user-secrets set "Admin:Email" "your-email@example.com"
```

5. Apply the existing Entity Framework Core migrations.

```powershell
dotnet ef database update
```

6. Start the application.

```powershell
dotnet watch
```

7. Open the local URL displayed in the terminal.

Register or sign in using the email configured for the Manager role to access restricted functionality.

## Database Structure

HomeKeep uses Entity Framework Core with SQL Server.

The main application entities are:

**MaintenanceTask**
- Stores maintenance details, schedules, and completion status.
- Has a one-to-many relationship with MaintenanceLog.

**MaintenanceLog**
- Records completed maintenance activity.
- References its associated MaintenanceTask.

ASP.NET Core Identity manages user accounts, roles, and authentication data.

## Deployment

HomeKeep is deployed to Microsoft Azure.

The deployed application uses its configured SQL Server connection and administrator email settings.

The same MVC pages and API endpoints are available on the deployed website.

## Project Development

HomeKeep was developed incrementally throughout the semester, including:

- MVC application structure and database integration.
- Maintenance task management.
- Maintenance history and related data.
- User authentication and role-based authorization.
- UI improvements, navigation, and custom error pages.
- REST API endpoints, DTOs, validation, and API authorization.
- Azure deployment and testing.

Git commits document the implementation of individual features and improvements
