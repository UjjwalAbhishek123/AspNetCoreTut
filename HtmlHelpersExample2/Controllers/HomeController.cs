using HtmlHelpersExample2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HTMLHelpersExample2.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            //for demonstrating Dropdown List
            //demosntrating how to fetch data for dropdown from DB
            List<Department> ListDepartments = new List<Department>()
            {
                //Add IT dept to list with Id=1, Name="IT"
                new Department(){ DeptId = 1, DeptName = "IT"},

                //Add HR dept to list with Id=2, Name="HR"
                new Department(){ DeptId = 2, DeptName = "HR"},

                //Add Payroll dept to list with Id=3, Name="Payroll"
                new Department(){ DeptId = 3, DeptName = "Payroll"}
            };

            ViewBag.Departments = new SelectList(ListDepartments, "DeptId", "DeptName");

            //For demonstrating DropDownListFor
            //create one employee
            Employee emp = new Employee()
            {
                EmployeeId = 1,
                EmployeeName = "Ujjwal",
                Gender = "Male",
                DepartmentId = 2
            };

            //pass employee to view
            return View(emp);
        }
    }
}
