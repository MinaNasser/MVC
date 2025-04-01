using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository DeptREpo;
        IEmployeeRepository EmployeeREpo;

        public DepartmentController(IDepartmentRepository deptRepo, IEmployeeRepository empRepo)
        {
            DeptREpo = deptRepo;
            EmployeeREpo = empRepo;
        }

        public IActionResult DeptEmps()
        {
            return View("DeptEmps", DeptREpo.GetAll());
        }

        public IActionResult GetEmpsByDEptId(int deptId)
        {
            var employees = EmployeeREpo.GetByDEptID(deptId)
                .Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.Address,
                    DepartmentName = e.Department.Name // تجنب تحميل الكائن بالكامل
                }).ToList();

            return Json(employees);
        }


        [Authorize]
        public IActionResult Index()
        {
            List<Department> departmentList = DeptREpo.GetAll();
            return View("Index", departmentList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult SAveAdd(Department newDeptFromRequest)
        {
            if (newDeptFromRequest.Name != null)
            {
                DeptREpo.Add(newDeptFromRequest);
                DeptREpo.Save();
                return RedirectToAction("Index");
            }
            return View("Add", newDeptFromRequest);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var department = DeptREpo.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View("Edit", department);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult SaveEdit(Department department)
        {
            if (ModelState.IsValid)
            {
                Department temp = DeptREpo.GetById(department.Id);
                if (temp != null)
                {
                    temp.Name = department.Name;
                    DeptREpo.Update(temp);
                    DeptREpo.Save();
                }
                return RedirectToAction("Index");
            }
            return View("Edit", department);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            Department department = DeptREpo.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            DeptREpo.Delete(department.Id);
            DeptREpo.Save();
            return RedirectToAction("Index");
        }
    }
}
