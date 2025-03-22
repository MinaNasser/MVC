using WebApp.Models;
using WebApp.ViewModel;

namespace WebApp.Extentions
{
    public static class EmployeeExtensions
    {
        public static EmpWithDEptListViewModel Expand(this Employee emp, List<Department> departments)
        {
            return new EmpWithDEptListViewModel
            {
                Id = emp.Id,
                Name = emp.Name,
                Salary = emp.Salary,
                JobTitle = emp.JobTitle,
                ImageURL = emp.ImageURL,
                Address = emp.Address,
                DepartmentID = emp.DepartmentId,
                DeptList = departments
            };
        }
    }
}
