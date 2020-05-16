# ASP.NET-Core-MVC-Trial-1

## ASP.NET MVC Core CRUD Web App using Entity Framework Core Database First Approach

Basic CRUD App based on the tutorial in this [link][efcore-db-first-tutorial] but with some modifications particularly on querying and displaying a **one-to-many** relationship between two resources. For this sample app, there are two resources - **Employees** and **Skills**. The data relationship between the two is **one-to-many** - a single Employee has many Skills. On the index page (**/employees**) of the Employees resource, instead of displaying the **SkillID** property, we are displaying the actual skill Title. On the details page of a single Skill resource (**/skills/:id**), the Employees with that skill are also displayed.

### Notes on **app.UseBrowserLink**

1. Install the **Microsoft.VisualStudio.Web.BrowserLink** via the Nuget package manager. For more information, see this [link][use-browser-link-error]

### Notes on Connection Strings

1. For Microsoft SQL Server 2014 Express, see this [link][mssql-2014-conn-string] for documentation on valid connection strings
2. To get the **connection string** for a specific database on your MS SQL Server Express, first make sure that you've added the MS SQL Server Express in your **SQL Server Object Explorer**. You can do this by opening the SQL Server Object Explorer pane, then right-click on **SQL Server** and choose **Add SQL Server**. Once you've added your MS SQL Server Express, expand the dropdown list for the MS SQL Server Express then find the database name you wanted to use. Expand the dropdown list on the desired database then right-click on the database and choose **Properties**.

   ![alt text][get-conn-string-1]

   A **Properties** tab should open which contains several properties related to the database. On this tab, find the **Connection String** property then copy its value.

   ![alt text][get-conn-string-2]

   Open the **appsettings.json** then add the copied connection string under **ConnectionStrings** field.

   - sample **appsettings.json** file with connection string

   ![alt text][get-conn-string-3]

   - sample configuration for the **ConnectionStrings** field in \*appsettings.json\*\*

     ```Javascript
     "ConnectionStrings": {
       "testDB": "Data Source=LAPTOP-VRPV043O\\SQLEXPRESS;Initial Catalog=testEFCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
     },
     ```

### Notes on Entity Framework Core DB First appoarch

1. See [this][efcore-db-first-tutorial2] tutorial on EF-Core DB-First approach on .NET core using the **Package Manager Console**
2. Documentation [link][scaffold-dbcontext] on **Scaffold-DbContext** usage on the **Package Manager Console**

[efcore-db-first-tutorial]: https://www.c-sharpcorner.com/article/entity-framework-database-first-in-asp-net-core2/
[use-browser-link-error]: https://github.com/dotnet/AspNetCore.Docs/issues/6337
[mssql-2014-conn-string]: https://www.connectionstrings.com/microsoft-data-sqlclient/
[efcore-db-first-tutorial2]: https://www.devart.com/dotconnect/postgresql/docs/EFCore-Database-First-NET-Core.html
[scaffold-dbcontext]: https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell#scaffold-dbcontext
[get-conn-string-1]: ./img/get-conn-string-1.png
[get-conn-string-2]: ./img/get-conn-string-2.png
[get-conn-string-3]: ./img/get-conn-string-3.png
