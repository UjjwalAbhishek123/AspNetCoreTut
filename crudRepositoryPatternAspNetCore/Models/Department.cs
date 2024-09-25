using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace crudRepositoryPatternAspNetCore.Models
{
    //the relationship between Department and Employee classes represents a one-to-many relationship.Here’s how it works:
    //Department Class:
    //    The Department class has a property Employees, which is a list of Employee objects.
    //    This indicates that "one department" can have "multiple employees".
    public class Department
    {
        public int DepartmentId {  get; set; }

        [Required]
        public string Name {  get; set; }
        public List<Employee> Employees { get; set; }
    }
}
