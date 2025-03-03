namespace WebApi.Helpers;

using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

public class DataContext : DbContext
{

    public DbSet<Intern> Interns { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
    : base(options) { }

}