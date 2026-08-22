using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// ---------- Services ----------
builder.Services.AddControllers();   // enables Controller-based routing (like ProductsController)

// Read the connection string named "DefaultConnection" out of appsettings.json.
// builder.Configuration is ASP.NET's built-in reader for appsettings.json (like Spring's @Value/application.properties reading).
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register AppDbContext with Dependency Injection.
// Whenever any class (e.g. a Repository or Service) asks for AppDbContext in its constructor,
// ASP.NET will create one, configured to talk to MySQL using the connection string above.
// ServerVersion.AutoDetect() figures out which exact MySQL version you're running automatically.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// ---------- HTTP pipeline ----------
app.MapControllers();   // tells ASP.NET to actually route incoming requests to your Controllers

app.Run();