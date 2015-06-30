using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Models;
using DataRepository.BaseClass;

namespace DataRepository
{
    public class DepartmentRepository : IRepository<Department>
    {

        public Department GetById(int id)
        {
            return GetAll().First(d => d.DepartmentId.Equals(id));
        }

        public IEnumerable<Department> GetAll()
        {
            IEnumerable<Department> result = null;
            using (var db = new EmployeeDbContext())
            {
                result = db.Departments.ToList();
            }
            return result;
        }

        public void InsertOnSubmit(Department entity)
        {
            using (var db = new EmployeeDbContext())
            {
                db.Departments.Add(entity);
                db.SaveChanges();
            }
        }

        public void UpdateOnSubmit(Department entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteOnSubmit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
