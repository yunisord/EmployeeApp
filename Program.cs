using EmployeeApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Retrieve connection string from appsettings.json

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
try
{
    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        Console.WriteLine("Connection successful!");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Connection failed: {ex.Message}");
}

// Add services to the container.
// ✅ Register SQL Server Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
var app = builder.Build();
// Serve static files (e.g., HTML, CSS, JS)
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
