using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Library.Business.Interfaces;

namespace Library.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IBookService _bookService;

        public HomeController(IMemberService memberService, IBookService bookService)
        {
            _memberService = memberService;
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            TempData["Active"] = "home";

            return View();
        }

        public IActionResult GetFiveMembersMostReadBook()
        {
            var jsonString = JsonConvert.SerializeObject(_memberService.GetFiveMembersMostReadBook());
            return Json(jsonString);
        }

        public IActionResult GetMostReadBook()
        {
            var jsonString = JsonConvert.SerializeObject(_bookService.GetMostReadBook());
            return Json(jsonString);
        }

        public IActionResult GetFiveMemberMostActive()
        {
            var jsonString = JsonConvert.SerializeObject(_memberService.GetFiveMembersMostActive());
            return Json(jsonString);
        }


    }
}
