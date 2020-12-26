using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Library.Business.Interfaces;

namespace Library.Web.Areas.Member.Controllers
{

    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class HomeController : Controller
    {
        private readonly UserManager<Entities.Concreate.Member> _userManager;
        private readonly IMemberService _memberService;

        public HomeController(UserManager<Entities.Concreate.Member> userManager, IMemberService memberService)
        {
            _userManager = userManager;
            _memberService = memberService;            
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "home";

            var member = _userManager.FindByNameAsync(User.Identity.Name).Result;

            ViewBag.readBookCount = (int)(await _memberService.GetReadBookCountAsync(member.Id));

            ViewBag.currentBookCount = await _memberService.GetCurrentBookCountAsync(member.Id);

            return View();
        }
    }
}
