using System.ComponentModel.DataAnnotations;

namespace CrudTest.Models
{
    public class ProgrammingLaguage
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }        
    }
}
