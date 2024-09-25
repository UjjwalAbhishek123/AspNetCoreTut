using crudRepositoryPatternAspNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace crudRepositoryPatternAspNetCore.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //Following variable is going to hold EfCoreDBContext
        //instance
        private readonly EfCoreDbContext _context;

        //Initializing the EfCoreDBContext instance
        //which it received as an argument
        //MVC Framework DI Container will provide
        //the EFCoreDbContext instance
        public EmployeeRepository(EfCoreDbContext context)
        {
            _context = context;
        }

        //Returns all employees from Database
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.Include(e => e.Department).ToListAsync();
        }

        //Gets Single Employee by their ID
        public async Task<Employee?> GetByIdAsync(int EmployeeID)
        {
            var employee = await _context.Employees.Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.EmployeeId == EmployeeID);

            return employee;
        }

        //Add new Employee to database
        public async Task InsertAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        //Updates an existing employee's details.
        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        //Deletes an employee from the database
        public async Task DeleteAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await SaveAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Employee with ID {employeeId} not found.");
            }
        }

        //InsertAsync, UpdateAsync, and DeleteAsync methods,
        //remember to call SaveAsync to commit the changes to the database.
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}
