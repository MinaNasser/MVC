using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult AddRole()
        {
            return View("AddRole");
        }
    }
}
