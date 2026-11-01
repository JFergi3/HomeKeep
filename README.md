# HomeKeep

Maintenance made simple.

HomeKeep organizes recurring home maintenance tasks and keeps a history
of completed work. Built by Jake Ferguson for .NET Web Development at WCTC.

**Live website:** http://homekeep-jf2026.azurewebsites.net
## What it does

- Create, view, edit, and delete maintenance tasks.
- Organize tasks by room, maintenance interval, and completion status.
- Record completed work with a date, name, and notes.
- View each task’s maintenance history, newest first.

## The three things I fixed for the midterm

1. Maintenance History blended into the page. I added a soft background,
   contrasting border, and padding to distinguish it from task details.
2. Buttons lacked clear grouping and spacing. I placed task actions near
   task details, separated Edit from Delete, and kept Log Work inside
   Maintenance History.
3. Mobile navigation felt crowded. I shortened the header brand, positioned
   the hamburger beside it, simplified navigation links, and fixed footer
   wrapping on narrow screens.

## Built with

ASP.NET Core MVC (.NET 10), Entity Framework Core, SQL Server,
Bootstrap, and the Bootswatch Lux theme.

## Running locally

Requires the .NET 10 SDK, Entity Framework Core CLI tools, and access
to a SQL Server database.

From the folder containing `HomeKeep.csproj`, run:

```bash
dotnet restore
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<your SQL Server connection string>"
dotnet ef database update
dotnet watch
```

Open the local URL printed in the terminal. Database credentials are
configured through user secrets and should not be committed.