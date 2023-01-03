using CrudTest.Models;
using CrudTest.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CrudTest.Dal;

public class EmployeesDbContext : DbContext
{ 
    public DbSet<ProgrammingLaguage> ProgrammingLaguages { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<EmployeeView> EmployeeViews { get; set; }

    public EmployeesDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}
