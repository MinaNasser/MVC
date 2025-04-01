using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Repository;


namespace WebApp.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IDepartmentRepository  deptREpo;

        public ServiceController(IDepartmentRepository deptREpo)
        {
            this.deptREpo = deptREpo;
        }


        public IActionResult TestAuth()
        {
            if(User.Identity.IsAuthenticated== true)
            {
               Claim claim =  User.Claims.FirstOrDefault( u=>u.Type == ClaimTypes.NameIdentifier);
                Claim address = User.Claims.FirstOrDefault(c => c.Type == "UserAddress");


                string id = claim.Value;

                string name = User.Identity.Name;
                
                return Content($"\n\n\n\t\t\t\tWelcom {name}\n \t\t\t\tID:{id} //// {address.Value}");
            }
               
            return Content("Welcom Guste ");
        }

        public IActionResult Index(int id)//[FromServices]IDepartmentRepository deptrr)
        {
            ViewBag.Id = deptREpo.Id;
            return View("Index");
        }
    }
}
