using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEFcoreAspNetCore.Models
{
    public class Student
    {
        //Id is Primary Key in DB
        [Key]
        public int Id { get; set; }

        //StudentName will be the coln name in Database when its generated
        [Column("StudentName", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("StudentGender", TypeName = "varchar(20)")]
        public string Gender { get; set; }
        
        public int Age { get; set; }

        public int Standard { get; set; }
    }
}
