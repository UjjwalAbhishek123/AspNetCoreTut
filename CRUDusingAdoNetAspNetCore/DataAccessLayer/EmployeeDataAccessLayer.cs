using CRUDusingAdoNetAspNetCore.Models;
using CRUDusingAdoNetAspNetCore.Utility;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace CRUDusingAdoNetAspNetCore.DataAccessLayer
{
    //Here we will have all the ADO.Net related work

    /*
     Model Class
        Definition: A model class is a representation of data. 
                    It contains properties that correspond to the columns in a database table.

        Purpose: The main purpose of a model class is to define the data structure. 
                 It is also used for data validation, serialization, and deserialization.

    Data Access Layer (DAL) Class
        Definition: A DAL class provides "methods to access data", such as CRUD operations (Create, Read, Update, Delete).
        Purpose: The main roles of the DAL include:
                    Data Access Logic: Encapsulating the logic for retrieving, updating, or deleting data from the database.
                    Abstraction: Separating business logic from database access details, 
                                 making the code cleaner and easier to understand.
                    Encapsulation of Queries: Handling interactions with SQL queries or 
                                    ORM (Object-Relational Mapping) frameworks (like Entity Framework).
     */
    public class EmployeeDataAccessLayer
    {
        //Getting connection string
        string cs = ConnectionString.dbcs;

        //Getting all Employee
        public List<Employees> GetAllEmployees()
        {
            /*
             * The empList is created to store the list of Employees retrieved from the database. 
             * It acts as a container for all the employee records you want to return from this method.
             */
            List<Employees> empList = new List<Employees>();

            /*
             * creating an instance of the SqlConnection class, which is used to connect to a SQL Server database. 
             * The cs variable typically holds the connection string, which includes information like the server name, 
             * database name etc.
             * 
             * The "using" statement is used to ensure that the SqlConnection object is properly disposed of 
             * once it goes out of scope. 
             * This is crucial for managing resources, as it automatically closes 
             * the connection to the database when the block is exited, either normally or due to an exception.
             * makes the code cleaner and easier to read, as you don't need to explicitly call con.Close()
             */
            using (SqlConnection con = new SqlConnection(cs))
            {
                //want to get all the Employees data, so using "spGetAllEmployee" stored procedure created in SQL server here
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);

                //telling the type of command we want to execute
                cmd.CommandType = CommandType.StoredProcedure;

                //Opening the Connection
                con.Open();

                /*
                 * declare a variable reader of type SqlDataReader, 
                 * which will hold the "result set returned by the SQL query" executed by cmd
                 * 
                 * cmd => refers to an instance of the SqlCommand class, which represents a SQL statement or stored procedure 
                 * that you want to execute
                 * 
                 * ExecuteReader() => This method of the SqlCommand class executes the command text (which could be a SQL query) 
                 * and returns a SqlDataReader object
                 */
                SqlDataReader reader = cmd.ExecuteReader();

                //to read all data in reader, till there is data present in Table
                while (reader.Read())
                {
                    //we want to read data from Employees table/Employees Model class
                    Employees emp = new Employees();

                    //getting all the properties of Employees class
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["name"].ToString() ?? "";
                    emp.Gender = reader["gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["age"]);
                    emp.Designation = reader["designation"].ToString() ?? "";
                    emp.City = reader["city"].ToString() ?? "";

                    //Adding employees to empList, one by one
                    empList.Add(emp);
                }
            }
            return empList;
        }

        //creating method to add employees
        public void AddEmployee(Employees emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                /*
                 * passing values to SQL commands
                 * 
                 * Parameters => This property of SqlCommand provides access to the collection of parameters for the command. 
                 *               Parameters are used to pass data to a SQL statement in a secure and efficient manner
                 * 
                 * AddWithValue() => This method adds a new parameter to the command’s parameter collection and assigns a value to it.
                 *                  The first argument is the name of the parameter (in this case, @name), and the second argument is the 
                 *                  value to assign to that parameter (emp.Name).
                 */
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@designation", emp.Designation);
                cmd.Parameters.AddWithValue("@city", emp.City);

                //Opening connection
                con.Open();

                /* 
                 * ExecuteNonQuery() in scenarios where you are performing operations that change the state of the database but do not need to retrieve any data. 
                 * This includes:Adding new records (e.g., INSERT). 
                 * Modifying existing records (e.g., UPDATE). 
                 * Removing records (e.g., DELETE). 
                 * Executing stored procedures that perform these operations.
                 */
                cmd.ExecuteNonQuery();
            }
        }

        //creating method to get employee by Id
        public Employees GetEmployeesByID(int? id)
        {
            Employees emp = new Employees();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from Employees where id = @id", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //getting all the properties of Employees class
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["name"].ToString() ?? "";
                    emp.Gender = reader["gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["age"]);
                    emp.Designation = reader["designation"].ToString() ?? "";
                    emp.City = reader["city"].ToString() ?? "";
                }
            }
            return emp;
        }

        //creating method to Update employee
        public void UpdateEmployee(Employees emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                /*
                 * passing values to SQL commands
                 * 
                 * Parameters => This property of SqlCommand provides access to the collection of parameters for the command. 
                 *               Parameters are used to pass data to a SQL statement in a secure and efficient manner
                 * 
                 * AddWithValue() => This method adds a new parameter to the command’s parameter collection and assigns a value to it.
                 *                  The first argument is the name of the parameter (in this case, @name), and the second argument is the 
                 *                  value to assign to that parameter (emp.Name).
                 */
                cmd.Parameters.AddWithValue("@id", emp.Id);
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@designation", emp.Designation);
                cmd.Parameters.AddWithValue("@city", emp.City);

                //Opening connection
                con.Open();

                /* 
                 * ExecuteNonQuery() in scenarios where you are performing operations that change the state of the database but do not need to retrieve any data. 
                 * This includes:Adding new records (e.g., INSERT). 
                 * Modifying existing records (e.g., UPDATE). 
                 * Removing records (e.g., DELETE). 
                 * Executing stored procedures that perform these operations.
                 */
                cmd.ExecuteNonQuery();
            }
        }

        //creating method to Delete Employee (by Id)
        public void DeleteEmployee(int? id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
