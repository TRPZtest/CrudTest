using CrudTest.Models;

namespace CrudTest.Dal;

public class EmployeesRepository 
{
    private readonly CrudTestDbContext _context;

    public EmployeesRepository(CrudTestDbContext context)
    {
        _context = context;
    }

    public async Task AddEmployee(Employee employee)
    {
        
    }

    public async Task UpdateEmployee(Employee employee)
    {

    }

}
