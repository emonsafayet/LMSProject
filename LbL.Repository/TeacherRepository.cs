using LbLModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LbL.Repository
{
    public class TeacherRepository
    {
        private BusinessDbContext db;
       
        public TeacherRepository()
        {
            this.db = new BusinessDbContext();
        }
        public bool Add(Teacher teacher)
        {
            teacher.Id = Guid.NewGuid().ToString();
            this.db.Teachers.Add(teacher);
            int savechanges = this.db.SaveChanges();
            return savechanges > 0;
        }

    }
}
