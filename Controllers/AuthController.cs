using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bugTracker.Models;
using bugTracker.Repositories;
using bugTracker.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace bugTracker.Controllers;

public class AuthController : Controller
{
    private SignInManager<ApplicationUser> _signInManager;
    private UserManager<ApplicationUser> _userManager;
    public AuthController(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel vm)
    {
        var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, false, false);
        if(!result.Succeeded)
        {
            return View(vm);
        }
    
        return RedirectToAction("Projects", "Home");

    }


    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        var user = new ApplicationUser
        {
            UserName = vm.Email,
            Email = vm.Email,
            Nome = vm.Nome + ' ' + vm.Sobrenome
        };

        var result = await _userManager.CreateAsync(user, vm.Senha);

        if(result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Projects", "Home");
        }

        return View(vm);
    }
    
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Projects", "Home");
    }



}