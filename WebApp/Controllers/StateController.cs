using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetSession(string name)
        {
            //logic
            HttpContext.Session.SetString("Name", name);
            //logic
            HttpContext.Session.SetInt32("Age", 21); 
            return Content("Data Session Save Success");
        }
        public IActionResult GetSession()
        {
            //logic
            string n = HttpContext.Session.GetString("Name");
            //logic
            int? a =HttpContext.Session.GetInt32("Age");
            return Content($"Name :- {n} :Age:- {a} ");
        }
        public IActionResult SetCookie()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            //logic
            HttpContext.Response.Cookies.Append("Name", "Mina");
            HttpContext.Response.Cookies.Append("Age", "25");
            return Content("Data Cookies Save Success");
        }
        public IActionResult GetCookie()
        {
            //logic
            string n = HttpContext.Request.Cookies["Name"];
            //logic
            string a = HttpContext.Request.Cookies["Age"];
            return Content($"Frome Cookies Name :- {n} :Age:- {a} ");
        }
    }
}
