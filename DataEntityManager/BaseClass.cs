using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityManager
{
    public class BaseClass
    {
        public BaseClass()
        {
        }


        public DateTime?  createdate { get; set; }
        [Required]
        public string  createdby { get; set; }
        [Required]
        public string  modifiedby { get; set; }

        public DateTime? modifieddate { get; set; }
    }
}
