namespace HtmlHelperExample3.Models
{
    public class Company
    {
        public int SelectedDepartment {  get; set; }
        public List<Department> Departments()
        {
            List<Department> ListDepartments = new List<Department>()
            {
                new Department(){ DeptId = 1, DeptName = "IT" },
                new Department(){ DeptId = 2, DeptName = "HR" },
                new Department(){ DeptId = 3, DeptName = "Manager" },
            };
            return ListDepartments;
        }
    }
}
