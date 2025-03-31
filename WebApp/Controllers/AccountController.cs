using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using WebApp.Models;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController
            (UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register
            (RegisterUserViewModel UserViewModel)
        {
            if (ModelState.IsValid)
            {
                //Mapping
                AppUser appUser = new AppUser();
                appUser.Address=UserViewModel.Address;
                appUser.UserName = UserViewModel.UserName;
                appUser.PasswordHash = UserViewModel.Password;

                //save database
                IdentityResult result= 
                    await userManager.CreateAsync(appUser,UserViewModel.Password);
                if (result.Succeeded)
                {
                    //assign to role
                    //await userManager.AddToRoleAsync(appUser, "Admin");
                    //Cookie
                    await signInManager.SignInAsync(appUser, false);
                    return RedirectToAction("Index", "Department");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Register", UserViewModel);
        }

        public IActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]//requets.form['_requetss]
        public async Task<IActionResult> Login(LoginUserViewModel userViewModel)
         {
            if (ModelState.IsValid==true)
            {
                //check found 
                AppUser appUser =
                    await userManager.FindByNameAsync(userViewModel.Name);
                if (appUser != null)
                {
                     
                    bool found = await userManager.CheckPasswordAsync(appUser, userViewModel.Password);
                    if (found == true) 
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("UserAddress",appUser.Address));
                        //claims.Add(new Claim("UserAddress",appUser.Address));
                        await signInManager.SignInWithClaimsAsync(appUser,userViewModel.RememberMe ,claims);
                        //await signInManager.SignInAsync(appUser, userViewModel.RememberMe);
                        return RedirectToAction("index", "department");
                    }
                }
                ModelState.AddModelError("", "Username OR PAssword wrong");
                //create cookie
            }
            return View("Login", userViewModel);
        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return View("Login");
        }
    }
}
