using System.Diagnostics.CodeAnalysis;

namespace CrudTest.Models.ViewModels
{
    public class AddEmployeeViewModel
    {    
        public IEnumerable<ProgrammingLaguage>? ProgrammingLaguages { get; set; }
        public IEnumerable<Department>? Departments { get; set; }

    }
}
