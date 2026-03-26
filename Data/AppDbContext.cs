using Microsoft.EntityFrameworkCore;
using EMMapp.Models;

namespace EMMapp.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

    public DbSet<Registration> Registrations{get; set;}
}