using AutoMapper;
using Library.Business.Interfaces;
using Library.DTO.DTOs.BookDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class CurrentBooksController : Controller
    {
        private readonly UserManager<Entities.Concreate.Member> _userManager;
        private readonly IBookService _bookService;
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public CurrentBooksController(IRequestService requestService, UserManager<Entities.Concreate.Member> userManager, IBookService bookService, IMapper mapper)
        {
            _userManager = userManager;
            _bookService = bookService;
            _requestService = requestService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "currentbooks";

            var member = _userManager.FindByNameAsync(User.Identity.Name).Result;

            var db_takenBooks = await _bookService.GetBooksOfMemberWithAllAsync(member.Id);

            var takenBookList = new List<BookListTakenDto>();

            foreach (var db_takenBook in db_takenBooks)
            {
                var takenBook = new BookListTakenDto()
                {
                    Id = db_takenBook.Book.Id,
                    AuthorId = db_takenBook.Book.AuthorId,
                    Author = db_takenBook.Book.Author,
                    LongDescription = db_takenBook.Book.LongDescription,
                    Name = db_takenBook.Book.Name,
                    PublishedTime = db_takenBook.Book.PublishedTime,
                    PageNumber = db_takenBook.Book.PageNumber,
                    Picture = db_takenBook.Book.Picture,
                    Requests = db_takenBook.Book.Requests,
                    MemberId = member.Id
                };

                takenBookList.Add(takenBook);

            }

            return View(takenBookList);
        }


        [HttpPost]
        public async Task<IActionResult> Index(string readBookId, string memberId)
        {
            TempData["Active"] = "currentbooks";

            var db_readMemberBook = await _bookService.IsReadSameBookBeforeAsync(await _bookService.GetMemberBookByBookIdAsync(Convert.ToInt32(readBookId), Convert.ToInt32(memberId)));

            var db_recordedMemberBook = await _bookService.GetMemberBookByBookIdAsync(Convert.ToInt32(readBookId), Convert.ToInt32(memberId));

            if (db_readMemberBook == null)
            {
                db_recordedMemberBook.isRead = true;

                await _bookService.UpdateMemberBookTableAsync(db_recordedMemberBook);
            }

            else
            {
                var db_deletedMemberBook = await _bookService.IsNotReadSameBookBeforeAsync(await _bookService.GetMemberBookByBookIdAsync(Convert.ToInt32(readBookId), Convert.ToInt32(memberId)));

                await _bookService.RemoveMemberBookTableAsync(db_deletedMemberBook);
            }


            return RedirectToAction("Index", "CurrentBooks");
        }
    }
}
