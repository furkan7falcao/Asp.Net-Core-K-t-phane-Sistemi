using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Library.Business.Interfaces;
using Library.DTO.DTOs.MemberDtos;
using Library.Entities.Concreate;

namespace Library.Web.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<Member> _userManager;
        private readonly IRequestService _requestService;
        public Wrapper(UserManager<Member> userManager , IRequestService requestService)
        {
            _userManager = userManager;
            _requestService = requestService;
        }

        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;

            MemberListDto model = new MemberListDto();

            model.Id = user.Id;
            model.FullName = user.FullName;
            model.Picture = user.Picture;

            var okunmayanBildirimler = _requestService.getUnReadNotificationCount(user.Id);

            ViewBag.bildirimSayisi = okunmayanBildirimler;

            var roles = _userManager.GetRolesAsync(user).Result;

            if (roles.Contains("Admin"))
            {
                return View(model);
            }

            return View("Member", model);
        }



    }
}
