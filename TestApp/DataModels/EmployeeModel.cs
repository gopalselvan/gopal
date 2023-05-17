using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TestApp.DataModels
{
    [Table("employee")]
    public class EmployeeModel
    {
        [Key]
        public int employeeid { get; set; }
        public string employeename { get; set; }
        public string fathername { get; set; }
        public DateTime dob { get; set; }
        public char employeedesignation { get; set; }
        public string gender { get; set; }
        public string skill1 { get; set; }
        public string skill2 { get; set; }
        public string skill3 { get; set; }
        public string skill4 { get; set; }
        public string skill5 { get; set; }
    }
}
