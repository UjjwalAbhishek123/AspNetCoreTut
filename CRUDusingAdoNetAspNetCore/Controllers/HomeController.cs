using CRUDusingAdoNetAspNetCore.DataAccessLayer;
using CRUDusingAdoNetAspNetCore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUDusingAdoNetAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        /*
         * declaring a private, immutable field that holds an instance of the EmployeeDataAccessLayer class. 
         * This instance can be used to access employee-related data
         */
        private readonly EmployeeDataAccessLayer _empDAL;

        //creating object in constructor, for security technique
        public HomeController()
        {
            _empDAL = new EmployeeDataAccessLayer();
        }

        public IActionResult Index()
        {
            //Fetching the records of employees in List, received by GetAllEmployees()
            List<Employees> emps = _empDAL.GetAllEmployees();
            return View(emps);
        }

        //GET: Create / Add Employees
        public IActionResult Create()
        {
            return View();
        }

        //POST: Create / Add Employees
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employees emp)
        {
            try
            {
                _empDAL.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }

        //GET: Edit Employees
        public IActionResult Edit(int id)
        {
            Employees emp = _empDAL.GetEmployeesByID(id);
            return View(emp);
        }

        //POST: Edit / Update Employees
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employees emp)
        {
            try
            {
                _empDAL.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: Details Employees by id
        public IActionResult Details(int id)
        {
            Employees emp = _empDAL.GetEmployeesByID(id);
            return View(emp);
        }

        //GET: Delete Employees by id
        public IActionResult Delete(int id)
        {
            Employees emp = _empDAL.GetEmployeesByID(id);
            return View(emp);
        }

        //POST: Delete Employees
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employees emp)
        {
            try
            {
                _empDAL.DeleteEmployee(emp.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
