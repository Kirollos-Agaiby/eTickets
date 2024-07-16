using eTickets.Data;
using eTickets.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
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
        public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
        {
            if(ModelState.IsValid)
            {
                // Mapping from VM to Model
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.Address = newUserVM.Address;
                applicationUser.UserName = newUserVM.UserName;
                applicationUser.PasswordHash = newUserVM.Password;

                // Save db
                IdentityResult result = await userManager.CreateAsync(applicationUser, newUserVM.Password); 
                if(result.Succeeded)
                {
                    // Create Cookie                                 Persistent/Session
                    await signInManager.SignInAsync(applicationUser, false);
                    return RedirectToAction("Index", "Movies");
                }
                else
                {
                    // result.Errors -> IEnumerable
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("Password", errorItem.Description);
                    }
                }
                return View();
            }
            return View("Register", newUserVM);
        }


        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Register");
        }
    }
}
