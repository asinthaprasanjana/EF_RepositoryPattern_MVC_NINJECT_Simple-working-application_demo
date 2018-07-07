using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataEntityManager
{
    public class Marks : BaseClass
    {
        public Marks()
        {

        }
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Maths { get; set; }
        [Required]
        public int Science { get; set; }
        [Required]
        public int Language { get; set; }

        //public IList<Student> Students { get; set; }


    }
}