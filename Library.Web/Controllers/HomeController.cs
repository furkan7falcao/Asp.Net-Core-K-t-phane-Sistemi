using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Library.DTO.DTOs.MemberDtos;
using Library.Entities.Concreate;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Member> _userManager;
        private readonly SignInManager<Member> _signInManager;

        public HomeController(UserManager<Member> userManager, SignInManager<Member> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View(new MemberSignInDto());
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(MemberSignInDto model)
        {
            if (ModelState.IsValid)
            {
                var member = await _userManager.FindByNameAsync(model.UserName);

                if (member != null)
                {
                    var resultLogin = await _signInManager.PasswordSignInAsync(model.UserName, model.Password,
                        model.RememberMe, false);

                    if (resultLogin.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(member);

                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }

                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                    }

                    ModelState.AddModelError("", "Kullanıcı Adı veya Parola hatalı");

                }

                else ModelState.AddModelError("", "Böyle bir üye bulunamadı.");

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new MemberSignUpDto());
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(MemberSignUpDto model, IFormFile Picture)
        {
            if (ModelState.IsValid)
            {
                var isExist = await _userManager.FindByNameAsync(model.UserName);

                if (isExist == null)
                {
                    var member = new Member
                    {
                        SecurityStamp = Guid.NewGuid().ToString(),
                        BirthYear = model.BirthYear,
                        Email = model.Email,
                        UserName = model.UserName,
                        FullName = model.FullName,
                        PhoneNumber = model.PhoneNumber
                    };

                    if (Picture != null)
                    {
                        string uzanti = Path.GetExtension(Picture.FileName);
                        string pictureName = Guid.NewGuid() + uzanti;
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + pictureName);


                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await Picture.CopyToAsync(stream);
                        }

                        member.Picture = pictureName;
                    }

                    var resultRegist = await _userManager.CreateAsync(member, model.Password);

                    if (resultRegist.Succeeded)
                    {
                        var resultRole = await _userManager.AddToRoleAsync(member, "Member");

                        if (resultRole.Succeeded)
                        {
                            return RedirectToAction("SignIn", "Home");
                        }

                        foreach (var error in resultRole.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                    }

                    foreach (var error in resultRegist.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }

                else ModelState.AddModelError("", "Böyle bir üye zaten mevcut");

            }

            return View(model);
        }


    }
}
