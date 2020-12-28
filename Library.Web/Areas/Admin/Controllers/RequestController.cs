using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Business.Interfaces;
using Library.DTO.DTOs.LendingDtos;
using Library.DTO.DTOs.RequestDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly UserManager<Entities.Concreate.Member> _userManager;
        private readonly IMapper _mapper;
        private readonly IMemberService _memberService;
        private readonly IBookService _bookService;

        public RequestController(IBookService bookService, IMemberService memberService, IRequestService requestService, UserManager<Entities.Concreate.Member> userManager, IMapper mapper)
        {
            _requestService = requestService;
            _bookService = bookService;
            _userManager = userManager;
            _memberService = memberService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "request";

            var admin = _userManager.FindByNameAsync(User.Identity.Name).Result;

            var db_requests = await _requestService.getUnReadRequestsOfMemberAsync(admin.Id);

            var requestList = new List<RequestListDto>();

            foreach (var db_request in db_requests)
            {
                var request = new RequestListDto();

                request.Id = db_request.Id;
                request.Description = db_request.Description;
                request.State = db_request.State;
                request.PosterMemberId = db_request.PosterMemberId;
                request.PosterMember = db_request.PosterMember;
                request.WantedBook = db_request.WantedBook;
                request.WantedBookId = db_request.WantedBookId;
                
                requestList.Add(request);
            };

            return View(requestList);
        }



        [HttpPost]
        public async Task<IActionResult> Index(string requestId)
        {
            TempData["Active"] = "notification";

            var request = await _requestService.FindByIdAsync(Convert.ToInt32(requestId));

            var customLendingModel = new LendingListDto
            {
                WantedBookId = request.WantedBookId,
                WantedBook = request.WantedBook,
                PosterMemberId = request.PosterMemberId,
                PosterMember = request.PosterMember
            };

            return RedirectToAction("Index", "Lending", customLendingModel);
        }


    }
}
