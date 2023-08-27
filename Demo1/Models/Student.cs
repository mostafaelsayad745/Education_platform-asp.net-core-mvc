using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int? deptNo { get; set; } = 1;
        [ForeignKey("deptNo")]
        public Department? dept { get; set; }
    }
}
