using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TestApp.DataModels
{
    [Table("student")]
    public class StudentModel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public decimal gpa { get; set; }
    }
}
