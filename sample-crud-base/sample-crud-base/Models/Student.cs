using System.ComponentModel.DataAnnotations;

namespace sample_crud_base.Models
{
    public class Student
    {
        [Key]
        public int? id { get; set; }
        public string? stname { get; set; }
        public string? course { get; set; }

     
    }
}
