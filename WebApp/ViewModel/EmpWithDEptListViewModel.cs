
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models;

namespace WebApp.ViewModel
{
    public class EmpWithDEptListViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        //[DataType(DataType.Password)]

        public string Name { get; set; }

        public int Salary { get; set; }

        public string JobTitle { get; set; }
        [Required (ErrorMessage ="You Must Upload Image or Re Upload") ]
        public string ImageURL { get; set; }

        public string? Address { get; set; }


        public int DepartmentID { get; set; }

        public List<Department> DeptList { get; set; }
    }
}
