using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntityManager;

namespace DataEntity.Repository
{
    public class StudentRepository:Repository<Student>
    {
        public Student GetStudent(int id)
        {
            var student  = base.context.Students.AsNoTracking().FirstOrDefault(p => p.StudentId.Equals(id));
            return student;
        }
    }
}
