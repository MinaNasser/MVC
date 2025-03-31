using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult AddRole()
        {
            return View("AddRole");
        }
        public IActionResult SaveRole(RoleVM role) {
            if (ModelState.IsValid)
            {

            }
            return View("AddRole",role);


        }
    }
}
