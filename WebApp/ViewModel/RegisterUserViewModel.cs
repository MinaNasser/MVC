using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModel
{
    public class RegisterUserViewModel
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }


    }
}
