using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Method must Public
        /// can't be  Static
        /// can't  be Overload
        /// </summary>

        //Home/ShowMsg 

        //public string ShowMsg()
        //{

        //    return "Hello Mina MCV";
        //}
        public ContentResult ShowMsg()
        {
            ContentResult result = new ContentResult();

            result.Content = "Hello Mina From Content Result";
            return result;



            //return "Hello Mina MCV";

        }
        public ViewResult ShowView()
        {
            ViewResult view = new ViewResult();
            view.ViewName = "View1";
            return view;

        }

        public IActionResult ShowMix(int id)
        {
            if (id % 2 == 0)
            {
                //ViewResult view = new ViewResult();
                //view.ViewName = "View1";
                //return view;
                return View("View1");
            }
            else
            {
                //ContentResult result = new ContentResult();

                //result.Content = "Hello Mina From Content Result";
                //return result;
                return Content("Hello Mina From Content Result");
            }
        }
 
        //public ViewResult view(string viewName)
        //{
        //    ViewResult view = new ViewResult();
        //    view.ViewName = viewName;
        //    return view;
        //}


        // Action for form  

         


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
