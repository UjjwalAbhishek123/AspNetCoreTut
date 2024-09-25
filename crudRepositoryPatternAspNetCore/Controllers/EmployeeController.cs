using crudRepositoryPatternAspNetCore.Models;
using crudRepositoryPatternAspNetCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace crudRepositoryPatternAspNetCore.Controllers
{
    public class EmployeeController : Controller
    {
        //Other Than Employee Entity
        private readonly EfCoreDbContext _context;

        //For employee entity
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(EfCoreDbContext context, IEmployeeRepository employeeRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }

        //GET: Employees
        public async Task<IActionResult> Index()
        {
            //Getting all employees here by EmployeesRepository method GetAllAsync()
            var employees = await _employeeRepository.GetAllAsync();
            return View(employees);
        }

        // GET: Employees/Details/5 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepository.GetByIdAsync(Convert.ToInt32(id));

            if(employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create 
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Name,Email,Position,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepository.InsertAsync(employee);

                //Call SaveAsync to Insert the data into the database
                await _employeeRepository.SaveAsync();

                // Redirect to Index after creation
                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", employee.DepartmentId);

            return View(employee);

        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepository.GetByIdAsync(Convert.ToInt32(id));

            if(employee == null)
            {
                return NotFound();
            }

            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", employee.DepartmentId);

            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,Email,Position,DepartmentId")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeRepository.UpdateAsync(employee);
                    await _employeeRepository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var emp = await _employeeRepository.GetByIdAsync(employee.EmployeeId);
                    if (emp == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", employee.DepartmentId);
            
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepository.GetByIdAsync(Convert.ToInt32(id));
            
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee != null)
            {
                await _employeeRepository.DeleteAsync(id);
                await _employeeRepository.SaveAsync();
            }

            return RedirectToAction("Index", "Employee");
        }
    }
}
