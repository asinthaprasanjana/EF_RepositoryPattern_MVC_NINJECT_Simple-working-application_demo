using DataEntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity.Repository
{
    public interface IStudentRepo
    {
        IEnumerable<Student> Student { get; }
        Student SaveStudent(Student student);
        Student DeleteStudent(int id);
        Student UpdateStudent(Student student);
    }
}
