using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntityManager;

namespace DataEntity.Repository
{
    public class MarksRepository:Repository<Marks>
    {
        public Marks GetMarks(int id)
        {
            var MarkSet = base.context.Marks.AsNoTracking().FirstOrDefault(p => p.Id. Equals(id));
            return MarkSet;
        }
    }
}
