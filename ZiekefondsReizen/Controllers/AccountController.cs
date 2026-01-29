using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ZiekefondsReizen.Controllers
{
	public class AccountController : Controller
	{
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly UserManager<CustomUser> _userManager;

        public AccountController(SignInManager<CustomUser> signInManager, UserManager<CustomUser> userManger)
        {
            _signInManager = signInManager;
            _userManager = userManger;
        }
		public IActionResult LogIn()
		{
			return View();
		}
        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password,model.RememberMe,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is incorrect");
                    return View(model);
                }
            }
            return View(model);
        }
        public IActionResult AddAccount()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> AddAccount(AccountCreateViewModel model)
		{
            if(ModelState.IsValid)
            {
                CustomUser user = new CustomUser();
                user.UserName = model.Email;
                user.Achternaam = model.Achternaam;
                user.Voornaam = model.Voornaam;
                user.Straat = model.Straat;
                user.Huisnummer = model.Huisnummer;
                user.Gemeente = model.Gemeente;
                user.Postcode = model.Postcode;
                user.Geboortedatum = model.Geboortedatum;
                user.Huisdoktor = model.Huisdoktor;
                user.ContractNummer = model.ContractNummer;
                user.Email = model.Email;
                user.TelefoonNummer = model.TelefoonNummer;
                user.RekeningNummer =model.RekeningNummer;
                user.IsActief = true;
                user.IsHoofdMonitor = false;
                var result = await _userManager.CreateAsync(user, model.Wachtwoord);
                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Gebruiker");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
                
                
            
			}
            return View(model);
        }
    }
}
