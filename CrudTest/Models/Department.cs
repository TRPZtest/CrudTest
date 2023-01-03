using System.ComponentModel.DataAnnotations;

namespace CrudTest.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }    
        public int floor { get; set; }
    }
}
