using LbL.Repository;
using LbLModel.Students;
using LbLRequestModel;
using System.Collections.Generic;
using System.Linq;

namespace LbLService
{
    public class StudentService
    {
        private StudentRepository repository;

        public StudentService()
        {
            this.repository = new StudentRepository();
        }

        public bool Add(Student student)
        {

            return repository.Add(student);
        }
        public List<Student> Search(StudentRequestModel request)
        {
            //we need a queryable varialbe
            IQueryable<Student> students = this.repository.Get();

            //we add where clauses
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                students = students.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(request.Phone))
            {
                students = students.Where(x => x.Phone.ToLower().Contains(request.Phone.ToLower()));
            }

            students = students.OrderBy(x => x.Modified);

            if (!string.IsNullOrWhiteSpace(request.OrderBy))
            {
                if (request.OrderBy.ToLower() == "name")
                {
                    students = request.IsAscending ? students.OrderBy(x => x.Name) : students.OrderByDescending(x => x.Name);

                }
                if (request.OrderBy.ToLower() == "phone")
                {
                    students = request.IsAscending ? students.OrderBy(x => x.Phone) : students.OrderByDescending(x => x.Phone);

                }
            }
            students = students.Skip((request.Page - 1) * 10).Take(request.PerPageCount);

            //they we do the toList (to fetch resltant data to the memory)

            List<Student> list = students.ToList(); // hit to database and execute the Query
            return list;
        }
    }
}
