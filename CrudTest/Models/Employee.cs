using System.ComponentModel.DataAnnotations;

namespace CrudTest.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Surname { get; set; }
    [Required]
    public string? Department { get; set; }
    [Required]
    public string? ProgrammingLanguage { get; set; }
}
