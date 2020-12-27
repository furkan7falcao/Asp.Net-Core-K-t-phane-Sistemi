using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Library.DTO.DTOs.MemberDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class ProfileController : Controller
    {
        private readonly UserManager<Entities.Concreate.Member> _userManager;

        public ProfileController(UserManager<Entities.Concreate.Member> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "profile";

            var member = await _userManager.FindByNameAsync(User.Identity.Name);

            MemberListDto model = new MemberListDto();

            model.Id = member.Id;
            model.FullName = member.FullName;
            model.PhoneNumber = member.PhoneNumber;
            model.Email = member.Email;
            model.Picture = member.Picture;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(MemberListDto model,IFormFile Picture)
        {
            TempData["Active"] = "profile";

            if (ModelState.IsValid)
            {
                var updatedMember = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);

                if(Picture != null)
                {
                    string uzanti = Path.GetExtension(Picture.FileName);
                    string pictureName = Guid.NewGuid() + uzanti;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + pictureName);


                    using (var stream = new FileStream(path,FileMode.Create))
                    {
                        await Picture.CopyToAsync(stream);
                    }

                    updatedMember.Picture = pictureName;

                }

                updatedMember.FullName = model.FullName;
                updatedMember.PhoneNumber = model.PhoneNumber;
                updatedMember.Email = model.Email;

                var result = await _userManager.UpdateAsync(updatedMember);

                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme Başarıyla Gerçekleşti";
                    return RedirectToAction("Index");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }

            return View(model);
        }


    }
}
