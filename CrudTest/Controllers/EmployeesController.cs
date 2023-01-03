using System.Diagnostics;
using CrudTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudTest.Controllers;


public class EmployeesController : Controller
{
    [Route("/add")]
    [HttpGet]
    public async Task<IActionResult> AddEmployee()
    {
        return View();
    }

    [Route("/add")]
    [HttpPost]      
    public async Task<IActionResult> AddEmployee([FromBody]Employee employee)
    {             
        if (!ModelState.IsValid)
            return  BadRequest(new ResponseMessage() { Message = "Validation error" } );

        

        return  BadRequest(new ResponseMessage() { Message = "Test" } );
       
    }
    
    // [Route("/edit")]
    // [HttpGet]
    // public async Task<IActionResult> EditEmployee()
    // {

    //     return View()
    // }

}
