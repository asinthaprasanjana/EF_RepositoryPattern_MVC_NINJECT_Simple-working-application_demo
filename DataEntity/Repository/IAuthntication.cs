using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity.Repository
{
   public  interface IAuthntication
    {
        bool AuthenticacteForm(string username, string password);
       
    }
}
