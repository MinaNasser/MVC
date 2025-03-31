using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModel
{
    public class LoginUserViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
