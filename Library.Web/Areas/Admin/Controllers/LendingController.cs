using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Business.Interfaces;
using Library.DTO.DTOs.LendingDtos;
using Library.DTO.DTOs.MemberBookDtos;
using Library.Entities.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LendingController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public LendingController(IBookService bookService, IMemberService memberService, IRequestService requestService, IMapper mapper)
        {
            _bookService = bookService;
            _requestService = requestService;
            _memberService = memberService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Index(LendingListDto model)
        {
            TempData["Active"] = "lending";

            if (model.WantedBookId == 0 || model.PosterMemberId == 0) // tüm istekler  gelecek
            {
                var db_unReadRequests = await _requestService.GetAllUnReadRequestsAsync();

                var unReadRequestsList = new List<LendingListDto>();

                foreach (var db_unReadRequest in db_unReadRequests)
                {
                    var request = new LendingListDto();

                    request.Id = db_unReadRequest.Id;
                    request.WantedBookId = db_unReadRequest.WantedBookId;
                    request.WantedBook = await _bookService.FindByIdAsync(request.WantedBookId);
                    request.PosterMemberId = db_unReadRequest.PosterMemberId;
                    request.PosterMember = await _memberService.FindByIdAsync(request.PosterMemberId);

                    unReadRequestsList.Add(request);
                };

                return View(unReadRequestsList);
            }

            else // bildirimden girilen istek gelecek
            {
                var request = await _requestService.GetSpecifyUnReadRequestAsync(_mapper.Map<LendingListDto, Request>(model));

                var unReadRequestsList = new List<LendingListDto>();

                unReadRequestsList.Add(new LendingListDto()
                {
                    Id = request.Id,
                    PosterMemberId = request.PosterMemberId,
                    PosterMember = request.PosterMember,
                    WantedBookId = request.WantedBookId,
                    WantedBook = request.WantedBook
                });

                return View(unReadRequestsList);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(string PosterMemberId, string WantedBookId, string RequestId)
        {
            TempData["Active"] = "lending";

            var db_deletedRequest = await _requestService.FindByIdAsync(Convert.ToInt32(RequestId));

            if (String.IsNullOrEmpty(PosterMemberId)) //vazgeç'e tıklandıysa
            {
                await _requestService.RemoveAsync(db_deletedRequest);

                //await _bookService.RemoveMemberBookAsync(db_memberBook);
            }
            else
            {

                var memberBook = new MemberBookAddDto
                {
                    BookId = Convert.ToInt32(WantedBookId),
                    MemberId = Convert.ToInt32(PosterMemberId),
                    isRead = false
                };

                await _bookService.AddMemberBookTableAsync(_mapper.Map<MemberBookAddDto, MemberBook>(memberBook));




                await _requestService.RemoveAsync(db_deletedRequest);
            }

            return RedirectToAction("Index", "Lending");
        }


    }
}
