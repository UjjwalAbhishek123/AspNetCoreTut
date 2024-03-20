namespace ControllersExample.Models
{
    public class Person
    {
        //It will contain all the Details of Person

        //creating properties
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
    }
}
