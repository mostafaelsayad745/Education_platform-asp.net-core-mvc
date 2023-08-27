using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Demo1.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string deptName { get; set; }
        public ICollection<Student> students { get; set; }
        public Department()
        {
            students = new HashSet<Student>();
        }
    }
}
