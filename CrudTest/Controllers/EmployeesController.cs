using System.Diagnostics;
using CrudTest.Dal;
using CrudTest.Models;
using CrudTest.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CrudTest.Controllers;


public class EmployeesController : Controller
{
    private readonly EmployeesRepository _repository;

    public EmployeesController(EmployeesRepository repository)
    {
        _repository = repository;
    }

    [Route("/add")]
    [HttpGet]
    public async Task<IActionResult> AddEmployee()
    {
        var languages =  await _repository.GetProgrammingLaguages();
        var departments = await _repository.GetDepartments();

        return View(new AddEmployeeViewModel { Departments = departments, ProgrammingLaguages = languages });
    }

    [Route("/add")]
    [HttpPost]      
    public async Task<IActionResult> AddEmployee([FromBody]Employee employee)
    {             
        if (!ModelState.IsValid)
            return  BadRequest(new ResponseMessage() { Message = "Validation error" } );
        try
        {
            await _repository.AddEmployee(employee);
            return Ok(new ResponseMessage() { Message = "Success", IsSuccess = true });
        }
        catch(Exception ex)
        {
            return BadRequest(new ResponseMessage() { Message = ex.Message, IsSuccess = false });
        }                          
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> EmployeesList()
    {

    }

}
