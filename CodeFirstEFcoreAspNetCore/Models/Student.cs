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
        [Required]
        public string Name { get; set; }

        [Column("StudentGender", TypeName = "varchar(20)")]
        [Required]
        public string Gender { get; set; }

        [Required]
        public int? Age { get; set; }

        [Required]
        public int? Standard { get; set; }
    }
}
