using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityManager
{
    public class Student : BaseClass
    {
        public Student()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Student ID", Order = 0)]
        public int StudentId { get; set; }
        [Required]

        [Column("FullName", Order = 1)]
        public string Name { get; set; }
        [Required]

        [Column("Age", Order = 2)]
        public int Age { get; set; }

        
        //[ForeignKey("Marks")]
        //[Column("Student Marks ID", Order = 3)]
        //public int? Marks_Id { get; set; }
        //public  Marks Marks { get; set; }


    }
}
