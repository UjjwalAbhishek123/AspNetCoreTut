namespace HTMLHelpersExample.Models
{
    //creating Employee model
    public class Employee
    {
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public string? City { get; set; }
        public decimal Salary { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
    }
}
