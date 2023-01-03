using System.Diagnostics;
using CrudTest.Dal;
using CrudTest.Models;
using CrudTest.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;

namespace CrudTest.Controllers;

[Route("")]
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
       
        var employees = await _repository.GetEmployeeViews();

        return View(employees);
    }

    [HttpGet]
    [Route("/DeleteEmployee")]
    public async Task<IActionResult> DeleteEmployee([FromQuery]int? id)
    {       
        var employees = await _repository.GetEmployeeViewById(id);

        if (employees.Count() == 0)
            return NotFound();

        await _repository.DeleteEmployee(id);

        return RedirectToAction("EmployeesList");
    }

    [Route("/edit")]
    public async Task<IActionResult> EditEmployee([FromQuery]int? id)
    {
        var employees = await _repository.GetEmployeeViewById(id);

        if (employees.Count() == 0)
            return NotFound();

        var viewModel = new EditEmployeeViewModel
        {
            ProgrammingLaguages = await _repository.GetProgrammingLaguages(),
            Departments = await _repository.GetDepartments(),
            EmployeeView = employees.First()
        };

        return View(viewModel);
    }

    [HttpPost]
    [Route("/edit")]
    public async Task<IActionResult> EditEmployee([FromBody]Employee employee)
    {
        try
        {
            var employees = await _repository.GetEmployeeViewById(employee.Id);

            if (employees.Count() == 0)
                throw new Exception("Employee was not found");

            await _repository.UpdateEmployee(employee);

            return Ok(new ResponseMessage() { Message = "Success", IsSuccess = true });
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseMessage() { Message = ex.Message, IsSuccess = false });
        }

    }

}
