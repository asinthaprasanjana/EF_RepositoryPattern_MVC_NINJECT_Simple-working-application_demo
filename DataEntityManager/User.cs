using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityManager
{
    public class User:BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

   
        public string PasswordSalt { get; set; }

      
        public int NumOfInvalidLogins { get; set; }

       
        public bool IsLoked { get; set; }

        public DateTime? LastLogin { get; set; }


    }
}
