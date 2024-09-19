namespace FileUploadDataToExcelAspNetCore3.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public long Salary { get; set; }
        public string Position { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
