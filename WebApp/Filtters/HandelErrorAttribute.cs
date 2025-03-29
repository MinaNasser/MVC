

namespace WebApp.Filtters
{
    public class HandelErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //ContentResult contentResult = new ContentResult();
            //contentResult.Content = "Some OF  Exception Throw ";
            //context.Result = contentResult; 

            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "Error";
            context.Result = viewResult;


        }
    }
}
