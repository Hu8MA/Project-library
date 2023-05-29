using Labrary2023.Data;
using Labrary2023.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Labrary2023.Controllers
{
    public class AccountController : Controller
    {
       

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

   
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, AppDbContext context)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            
        }



        [HttpGet]
        [AllowAnonymous]
       
        public IActionResult Register()
        {

            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();

                user.UserName = model.username;
                user.Email = model.email;



                var result = await userManager.CreateAsync(user, model.password);

                if (result.Succeeded)
                {

                    await signInManager.SignInAsync(user, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(model);
        }



        [HttpPost]
        [AllowAnonymous]
     
        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }



        [HttpGet]
        [AllowAnonymous]
  
        public IActionResult Login()
        {

            return View();

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(login model, string? returnUrl=null)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.username, model.password, true, false);

                if (result.Succeeded)
                {
                    if (returnUrl != null)
                    {
                        return LocalRedirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "the user is not Allowed ");
                }
            }

            return View(model);

        }



       
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
