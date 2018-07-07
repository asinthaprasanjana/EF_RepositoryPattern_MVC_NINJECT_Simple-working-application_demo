using DataEntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> User { get; }
        User AddNewUser(User student);

       // User Login(string username,string password);
        //Student DeleteStudent(int id);
        //Student UpdateStudent(Student student);
    }
}
