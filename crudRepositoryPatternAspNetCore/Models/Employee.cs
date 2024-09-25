using System.ComponentModel.DataAnnotations;

namespace crudRepositoryPatternAspNetCore.Models
{
    /*
     the relationship between Department and Employee classes represents a "one-to-many" relationship. Here’s how it works:
        Employee Class:
            The Employee class contains a DepartmentId property, which acts as a 
            foreign key referencing the Department to which the employee belongs.

            It also has a navigation property Department, which is of type Department. 
            This allows access to the department details from an employee instance.
     */
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Position { get; set; }

        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

    }
}
