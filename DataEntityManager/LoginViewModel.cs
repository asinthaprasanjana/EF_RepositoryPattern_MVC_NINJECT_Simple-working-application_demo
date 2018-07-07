using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityManager
{
    public class LoginViewModel
    {

        [Required(ErrorMessage ="User name required ")]
        public string username { get; set; }

        [Required(ErrorMessage ="Password required")]

        [StringLength(30, MinimumLength = 3)]
        public string password { get; set; }
      
    }
}
