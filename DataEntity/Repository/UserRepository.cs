using DataEntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity.Repository
{
    public class UserRepository :Repository<User>
    {
        public User GetUser(string name)
        {
            var user = base.context.Users.AsNoTracking().FirstOrDefault(p => p.Username==name);
            return user;
        }
    }
}
