using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

app.MapRazorPages();

app.Run();

public class Order // Добавлено public
{
    public int Id { get; set; }
    public int number { get; set; }
    public DateOnly addedDate { get; set; }
    public string? deviceType { get; set; }
    public string? deviceModel { get; set; }
    public string? description { get; set; }
    public string? client { get; set; }
    public string? phoneNumber { get; set; }
    public string? stage { get; set; }
    public string? status { get; set; }
    public string? master { get; set; } = "Не назначен";
    public string? masterComment { get; set; }
    public DateOnly? complitedDate { get; set; }
}

public class AppDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
}