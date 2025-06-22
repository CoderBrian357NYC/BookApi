using Microsoft.EntityFrameworkCore;
using BookApi.Data;
using BookApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite("Data Source=books.db"));

var app = builder.Build();

// Enable middleware to serve Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();  // Make sure DB is created

    if (!db.Books.Any())
    {
        db.Books.AddRange(
            new Book { Title = "Clean Code", Author = "Robert C. Martin", Year = 2008 },
            new Book { Title = "The Pragmatic Programmer", Author = "Andy Hunt", Year = 1999 }
        );
        db.SaveChanges();
    }
}




app.Run();
