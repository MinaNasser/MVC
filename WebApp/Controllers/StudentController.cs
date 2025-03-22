using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult ShowAll()
        {
            StudentsBL bL = new StudentsBL();   
           List<Student> StudentsListModel = bL.GetStudents();
            return View("ShowAll", StudentsListModel);// send Model List<Student>
        } 
        public IActionResult Details(int _id)
        {
            StudentsBL studentsBL = new StudentsBL();
            Student studentModel = studentsBL.GetStudentById(_id);
            return View("ShowDetails",studentModel);
        }



    }
}
