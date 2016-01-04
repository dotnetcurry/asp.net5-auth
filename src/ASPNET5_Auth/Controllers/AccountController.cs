using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using ASPNET5_Auth.Models;
using Microsoft.AspNet.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNET5_Auth.Controllers
{

    public class AccountController : Controller
    {
        //1
        private readonly UserManager<ApplicationUser> _securityManager;
        private readonly SignInManager<ApplicationUser> _loginManager;
        //2
        public AccountController(UserManager<ApplicationUser> secMgr, SignInManager<ApplicationUser> loginManager)
        {
            _securityManager = secMgr;
            _loginManager = loginManager;
        }

        //3
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        //4
        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                var result = await _securityManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _loginManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
            
            return View(model);
        }

        //5
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //6
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _loginManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToReturnUrl(returnUrl);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //7
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _loginManager.SignOutAsync();
            
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        //8
        private IActionResult RedirectToReturnUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
