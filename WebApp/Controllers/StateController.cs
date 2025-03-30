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
            options.Expires = DateTime.Now.AddDays(20);
            HttpContext.Response.Cookies.Append("Name", "Mina",options);
            HttpContext.Response.Cookies.Append("Age", "25",options);
            return Content("Cookies Saved");
        }

        public IActionResult GetCookie()
        {
            
            
            string name = HttpContext.Request.Cookies["Name"];
            string age = HttpContext.Request.Cookies["Age"];
            return Content($"Name :- {name} :Age:- {age} ");
        }
    }
}
