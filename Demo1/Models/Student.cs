using Demo1.CustomValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50,MinimumLength =3)]
        [Required]
        [Remote(action: "ValidateUserName", controller: "Student", ErrorMessage = "The userName exists choose another one.")]
        public string Name { get; set; }
        [MyRangeVaIidator(10,60)]
        public int Age { get; set; }
        //[RegularExpression(@"[a-zA-Z-9]+@[A-Za-z]+.[a-zA-Z]{2 , 4}") ]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MinLength(3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Student Password")]
        public string Cpassword { get; set; }
        public int? deptNo { get; set; } = 1;
        [ForeignKey("deptNo")]
        public Department? dept { get; set; }
    }
}
