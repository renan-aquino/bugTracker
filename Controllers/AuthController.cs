using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bugTracker.Models;
using bugTracker.Repositories;
using bugTracker.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace bugTracker.Controllers;

public class AuthController : Controller
{
    private SignInManager<IdentityUser> _signInManager;
    private UserManager<IdentityUser> _userManager;
    public AuthController(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager)
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
        var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false);
        if(!result.Succeeded)
        {
            return View(vm);
        }

        // var user = await _userManager.FindByNameAsync(vm.UserName);
        // var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        // if (isAdmin)
        // {

        // }
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

        var user = new IdentityUser
        {
            UserName = vm.Email,
            Email = vm.Email
        };

        var result = await _userManager.CreateAsync(user, "password");

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