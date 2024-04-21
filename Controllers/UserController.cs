using System.Threading.Tasks;
using LandingPage.Models;
using LandingPage.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace LandingPage.Controllers;

public class UserController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet,AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            User user = new()
            {
                Email = model.Email,
                UserName = model.UserName
            };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }

    [HttpGet, AllowAnonymous]
    public IActionResult Login(string? returnUrl)
    {
        return View(new LoginViewModel(){ReturnUrl = returnUrl});
    }

    [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            User? user = await _userManager.FindByEmailAsync(model.Email);
            SignInResult signInResult = await _signInManager.PasswordSignInAsync(
                user,
                model.Password,
                model.RememberMe,
                false);
            if (signInResult.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    Redirect(model.ReturnUrl);
                }

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty,"Некорректное логин или пароль");
        }

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}