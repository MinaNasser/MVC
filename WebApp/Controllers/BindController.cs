using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class BindController : Controller
    {
        // Bind/Test


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test(string name, int age, String[] color) 
        {
            // Request.Form["name"] = name;
            return Content($"""
                
                {name} 
                {age}
                """);
        }

        // Bind Collection


    }
}
