using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Extentions;
using WebApp.Models;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context   = new ITIContext();
        EmpWithDEptListViewModel EmpWithDEptListViewModel = new EmpWithDEptListViewModel();
        public IActionResult Index()
        {
            List<Employee> EmployeeList =context.Employee
                .Include(e=>e.Department)
                .ToList();
            return View("Index", EmployeeList);
        }

        public IActionResult Details(int id)
        {
            string msg = "Hello from Details Action From EmployeeController ";
            int tempretuer = 50;
            List<string> branch = new List<string>();
            branch.Add("Aswan");
            branch.Add("Alex");
            branch.Add("Assiut");
            //Aditinal data i need to send to view
            ViewData["Msg"] = msg;
            ViewData["Tempretuer"] = tempretuer;
            ViewData["Branchs"] = branch;

            ViewBag.color = "Red";
            Employee emp = context.Employee.FirstOrDefault(e => e.Id == id);

            return View("Details",emp);
        }

        public IActionResult DetailsViewModel(int id ) 
        {
            string msg = "Hello from Details Action From EmployeeController ";
            int tempretuer = 50;
            List<string> branch = new List<string>();
            branch.Add("Aswan");
            branch.Add("Alex");
            branch.Add("Assiut");
            //Aditinal data i need to send to view
            ViewData["Msg"] = msg;
            ViewData["Tempretuer"] = tempretuer;
            ViewData["Branchs"] = branch;

            ViewBag.color = "Red";
            Employee empModel = context
                .Employee.Include(e=>e.Department)
                .FirstOrDefault(e => e.Id == id);
            EmpDEptColorTempMSgBrchViewModel EV = new EmpDEptColorTempMSgBrchViewModel();
            EV.EmployeeName = empModel.Name;
            EV.DeptName = empModel.Department.Name;
            EV.Msg = msg;
            EV.Temprtuer = tempretuer;
            EV.Color=ViewBag.color;
            EV.Branches = branch;


            return View("DetailsViewModel",EV);
        }
        public IActionResult Edit(int id)
        {
            var employee = context.Employee.FirstOrDefault(e => e.Id == id);
            var departments = context.Department.ToList();

            if (employee == null)
            {
                return NotFound();
            }

            var viewModel = employee.Expand(departments);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult SaveEdit(Employee emp)  
        {
            
            if (ModelState.IsValid== true)
            {
                Employee temp = context.Employee.FirstOrDefault(e => e.Id == emp.Id);
                temp.Address = emp.Address;
                temp.Salary =emp.Salary;
                temp.Name = emp.Name;
                temp.JobTitle = emp.JobTitle;
                temp.DepartmentId = emp.DepartmentId;
                temp.ImageURL = emp.ImageURL;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", emp);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee employee = context.Employee.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            context.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index", "Employee");

        }
        [HttpGet]
        public IActionResult New()
        {
            ViewData["DeptList"] = context.Department.ToList();
            return View("New");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNewEmp(Employee empFromReq)
        {
            //if (empFromReq.Name !=null)
            if (ModelState.IsValid == true) 
            {
                if(empFromReq.DepartmentId != 0)
                {

                    context.Add(empFromReq);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError("DepartmentId", "Select  Department");
                    
                }
            }
            ViewData["DeptList"] = context.Department.ToList();
             return View("New",empFromReq);
        }
    }
}
