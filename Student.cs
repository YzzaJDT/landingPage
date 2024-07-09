using System.ComponentModel.DataAnnotations;

namespace ReactASPCrud.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string StName { get; set; }

        [Required, MaxLength(100)]
        public string course { get; set; }
    }
}
