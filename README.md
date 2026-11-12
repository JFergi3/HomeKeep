## Role-Based Authorization

HomeKeep uses ASP.NET Core Identity to manage authentication and role-based authorization.

### Manager Role

The `Manager` role controls who can create, edit, and delete maintenance tasks.

- **Visitors:** Can view maintenance tasks and their details without signing in.
- **Registered users:** Can sign in and record maintenance activity.
- **Managers:** Can create, edit, and delete maintenance tasks in addition to regular user functionality.

Users without the Manager role cannot access restricted maintenance task actions. Signed-in users who attempt to access these actions are redirected to a custom Access Denied page.

### Manager Configuration

HomeKeep uses a `RoleSeeder` to create the Manager role and assign it to the registered user whose email matches the `Admin:Email` configuration value.

For local development, configure the administrator email using .NET user secrets:

```powershell
dotnet user-secrets set "Admin:Email" "your-email@example.com"