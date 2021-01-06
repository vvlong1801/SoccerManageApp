using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoccerManageApp.Models.Account;

namespace SoccerManageApp.Controllers {
    public class AccountController : Controller {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController (UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
           
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return View("NotFound");
            }
            IdentityUser user=new IdentityUser()
            {
                UserName = model.Username,
                Email=model.Email
            };
            var result=await _userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user,"User");                
                await _signInManager.SignInAsync(user,isPersistent:false);
                return RedirectToAction("Index","Home");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
         public async Task<IActionResult> Login(LoginModel model,string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var user=await _userManager.FindByNameAsync(model.Username);
                var result=await _signInManager.PasswordSignInAsync(user,model.Password,model.RememberMe,false);
                if(result.Succeeded && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else if(result.Succeeded && !Url.IsLocalUrl(returnUrl))
                {
                   
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("","can't login");
                }
            }
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult AccessDenied()
        { 
            return View();
        }
    }
}