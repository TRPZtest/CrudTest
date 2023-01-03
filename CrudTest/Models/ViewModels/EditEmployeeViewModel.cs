namespace CrudTest.Models.ViewModels
{
    public class EditEmployeeViewModel
    {
        public EmployeeView? EmployeeView { get; set; }
        public IEnumerable<ProgrammingLaguage>? ProgrammingLaguages { get; set; }
        public IEnumerable<Department>? Departments { get; set; }
    }
}
