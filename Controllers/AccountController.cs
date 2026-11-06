using HomeKeep.Models;
using HomeKeep.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeKeep.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<HomeKeepUser> _userManager;
    private readonly SignInManager<HomeKeepUser> _signInManager;

    public AccountController(
        UserManager<HomeKeepUser> userManager,
        SignInManager<HomeKeepUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel form)
    {
        if (!ModelState.IsValid)
        {
            return View(form);
        }

        var user = new HomeKeepUser
        {
            UserName = form.Email,
            Email = form.Email
        };

        var result = await _userManager.CreateAsync(user, form.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(form);
        }

        await _signInManager.SignInAsync(user, isPersistent: false);
        return RedirectToAction("Index", "Home");
    }
}