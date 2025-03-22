using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext db = new();
        public IActionResult Index()
        {
            List<Department> DepartmentList = 
                db.Department.Include(d=>d.Employees).ToList();
            return View("Index",DepartmentList);
        }
        public IActionResult Add()
        {
            return View("Add"); 
        }
        //[HttpGet]
        [HttpPost]  
        public IActionResult SaveAdd(Department departmentFromReq)
        {


            if (departmentFromReq.Name != null)
            {
                db.Department.Add(departmentFromReq);
                db.SaveChanges(); 
                //return View("Index" );
                //call action from anther Action 
                return RedirectToAction("Index");
            }
            return View("Add", departmentFromReq);
        }
        public IActionResult Edit(int id)
        {
            var employee = db.Department.FirstOrDefault(e => e.Id == id);
            var departments = db.Department.ToList();

            if (employee == null)
            {
                return NotFound();
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult SaveEdit(Department department)
        {

            if (ModelState.IsValid == true)
            {
                Department temp = db.Department.FirstOrDefault(e => e.Id == department.Id);
                temp.Name = department.Name;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", department);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Department department = db.Department.FirstOrDefault(x => x.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            db.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index", "Department");

        }

    }
}
