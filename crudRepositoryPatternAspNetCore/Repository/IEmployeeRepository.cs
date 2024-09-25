using crudRepositoryPatternAspNetCore.Models;

namespace crudRepositoryPatternAspNetCore.Repository
{
    /*
    A repository interface typically includes methods covering basic CRUD operations (Create, Read, Update, Delete).
    That means these interfaces declare the operations you can perform on the entities.
    A repository typically does at least five operations as follows:

Selecting all records from a table
Selecting a single record based on its primary key
Insert a new record into the database
Update an existing record in the database
Delete an existing record in the database
    */
    public interface IEmployeeRepository
    {
        //This method returns all the Employee entities as an enumerable collection
        Task<IEnumerable<Employee>> GetAllAsync();

        //accepts an int parameter represnting Employee ID
        //returns a single employee matching with Employee ID
        Task<Employee> GetByIdAsync(int EmployeeID);

        //This method accepts an Employee object as the parameter
        //and
        //adds that Employee object to the Employees DbSet.
        //mark the entity state as Added
        Task InsertAsync(Employee employee);

        //This method accepts an Employee object as a parameter and
        //marks that Employee object as a modified Employee in the DbSet.
        Task UpdateAsync(Employee employee);

        //This method accepts an EmployeeID as a parameter and
        //removes that Employee entity from the Employees DbSet.
        //Mark the Entity state as Deleted
        Task DeleteAsync(int employeeId);

        //This method Saves changes to the EFCoreDb database.
        Task SaveAsync();
    }
}
