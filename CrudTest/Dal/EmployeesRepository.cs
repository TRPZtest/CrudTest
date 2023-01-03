using CrudTest.Models;
using CrudTest.Models.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CrudTest.Dal;

public class EmployeesRepository 
{
    private readonly EmployeesDbContext _context;

    public EmployeesRepository(EmployeesDbContext context)
    {
        _context = context;
    }

    public async Task AddEmployee(Employee employee)
    {
        var parameters = new List<SqlParameter>
        {
            new SqlParameter("@Name", employee.Name),
            new SqlParameter("@Surname", employee.Surname),
            new SqlParameter("@Age", employee.Age),
            new SqlParameter("@DepartmentId", employee.DepartmentId),
            new SqlParameter("@ProgrammingLanguageId", employee.ProgrammingLanguageId)
        };

        await _context.Database.ExecuteSqlRawAsync("dbo.AddEmployee @Name, @Surname, @Age, @DepartmentId, @ProgrammingLanguageId", parameters);
    }

    public async Task<List<ProgrammingLaguage>> GetProgrammingLaguages()
    {
        return await _context.ProgrammingLaguages.FromSqlRaw("GetProgrammingLanguages").ToListAsync();
    }

    public async Task<List<Department>> GetDepartments()
    {
        return await _context.Departments.FromSqlRaw("GetDepartments").ToListAsync();
    }

    public async Task<List<EmployeeView>> GetEmployeeViews()
    {
        return await _context.EmployeeViews.FromSqlRaw("GetEmployeeViews").ToListAsync();
    }

    public async Task UpdateEmployee(Employee employee)
    {

    }

}
