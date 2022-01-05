using Dot6.Razor.Crud.Demo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dot6.Razor.Crud.Demo.Data;

public class MyWorldDbContext : DbContext
{
    public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
    {
 
    }
    public DbSet<Cake> Cake { get; set; }
}