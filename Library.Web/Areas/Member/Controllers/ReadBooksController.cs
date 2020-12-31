using Library.Business.Interfaces;
using Library.DTO.DTOs.BookDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class ReadBooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly UserManager<Entities.Concreate.Member> _userManager;

        public ReadBooksController(IBookService bookService, UserManager<Entities.Concreate.Member> userManager)
        {
            _bookService = bookService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "readbooks";

            var member = _userManager.FindByNameAsync(User.Identity.Name).Result;

            var db_readBooks = await _bookService.GetReadBooksOfMemberAsync(member.Id);

            var readBookList = new List<BookListWithAuthorDto>();

            foreach (var db_readBook in db_readBooks)
            {
                var readBook = new BookListWithAuthorDto()
                {
                    Name = db_readBook.Book.Name,
                    Author = db_readBook.Book.Author,
                    AuthorId = db_readBook.Book.AuthorId,
                    PageNumber = db_readBook.Book.PageNumber,
                    PublishedTime = db_readBook.Book.PublishedTime
                };

                readBookList.Add(readBook);
            }

            return View(readBookList);
        }
    }
}
