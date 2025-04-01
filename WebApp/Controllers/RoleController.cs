using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.ViewModel;

namespace WebApp.Controllers
{

    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult AddRole()
        {
            return View("AddRole");
        }
        public async Task<IActionResult> SaveRole(RoleVM role) {
            if (ModelState.IsValid)
            {
                 IdentityRole iRole = new IdentityRole();

                iRole.Name = role.RoleName;
               IdentityResult result = await roleManager.CreateAsync(iRole);
                if (result.Succeeded)
                {
                    ViewBag.sucess = true;
                    return View("AddRole");
                }
                
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("AddRole",role);


        }
    }
}
