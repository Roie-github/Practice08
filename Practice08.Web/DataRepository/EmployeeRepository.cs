using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.BaseClass;
using Models;

namespace DataRepository
{
    public class EmployeeRepository : IRepository<Employee>
    {

        public IEnumerable<Employee> GetByFirstname(string name)
        {
            return GetAll().Where(e => e.FirstName.ToUpper().Contains(name.ToUpper())).ToList();
        }

        public Employee GetById(int id)
        {
            return GetAll().First(e => e.ID.Equals(id));
        }

        public IEnumerable<Employee> GetAll()
        {
            IEnumerable<Employee> result = null;
            using (var db = new EmployeeDbContext())
            {
                result = db.Employees.ToList();
                foreach (var item in result)
                {
                    item.EmployeeDepartment = db.Departments.Find(item.DepartmentId);
                }
            }
            return result;
        }

        public void InsertOnSubmit(Employee e)
        {
            using (var db = new EmployeeDbContext())
            {
                db.Employees.Add(e);
                db.SaveChanges();
            }
        }

        public void UpdateOnSubmit(Employee e)
        {
            using (var db = new EmployeeDbContext())
            {
                db.Entry(e).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteOnSubmit(int id)
        {
            using (var db = new EmployeeDbContext())
            {
                Employee remove = db.Employees.Find(id);
                db.Employees.Remove(remove);
                db.SaveChanges();
            }
        }
    }
}
