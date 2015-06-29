using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataRepository;
using Models;
using PagedList;

namespace Practice08.Web.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            EmployeeRepository er = new EmployeeRepository();
            IEnumerable<Employee> employeelist = null;

            //set Viewbag
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DeptSortParam = sortOrder == "dept" ? "dept_desc" : "dept";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

          
            ViewBag.CurrentFilter = searchString;

            employeelist = er.GetAll();

            //determine if searchString has value
            if (!String.IsNullOrEmpty(searchString))
            {
                employeelist = er.GetByFirstname(searchString);
            }
           
            //sortOrder
            switch (sortOrder)
            {
                case "name_desc":
                    employeelist = employeelist.OrderByDescending(e => e.FirstName);
                    break;
                case "dept_desc":
                    employeelist = employeelist.OrderByDescending(e => e.EmployeeDepartment.DepartmentName);
                    break;
                case "dept":
                    employeelist = employeelist.OrderBy(e => e.EmployeeDepartment.DepartmentName);
                    break;
                default:
                    employeelist = employeelist.OrderBy(e => e.FirstName);
                    break;
            }

            //set pagesize and pagenumber
            int pageSize = 5;
            int pageNumber = (page ?? 1);



            return View(employeelist.ToPagedList(pageNumber, pageSize));

        }

        [HttpGet]
        public ActionResult Create()
        {
            Employee e = new Employee();
            e.DepartmentList = new DepartmentRepository().GetAll();
            return View(e);
        }

        [HttpPost]
        public ActionResult Create(Employee e)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepository er = new EmployeeRepository();
                er.InsertOnSubmit(e);
                return RedirectToAction("Index");

            }
            else
            {
                e.DepartmentList = new DepartmentRepository().GetAll();
            }

            return View(e);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee e = new EmployeeRepository().GetById(id);

            e.DepartmentList = new DepartmentRepository().GetAll();
            return View(e);
        }
       

        public ActionResult Details(int id)
        {
            Employee e = new EmployeeRepository().GetById(id);

            e.DepartmentList = new DepartmentRepository().GetAll();
            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepository er = new EmployeeRepository();
                er.UpdateOnSubmit(e);
                return RedirectToAction("Index");

            }
            else
            {
                e.DepartmentList = new DepartmentRepository().GetAll();
            }

            return View(e);
        }


        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            Employee e = new EmployeeRepository().GetById(id);

            e.DepartmentList = new DepartmentRepository().GetAll();
            return View(e);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {

            EmployeeRepository er = new EmployeeRepository();
            er.DeleteOnSubmit(id);
            return RedirectToAction("Index");

        }

    }
}
