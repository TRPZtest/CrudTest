using System.ComponentModel.DataAnnotations;

namespace CrudTest.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } 
    [Required]
    public string Surname { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public int DepartmentId { get; set; }
    [Required]
    public int ProgrammingLanguageId { get; set; }
}
