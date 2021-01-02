using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Library.Business.Interfaces;
using Library.DTO.DTOs.BookDtos;
using Library.DTO.DTOs.RequestDtos;
using Library.Entities.Concreate;

namespace Library.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class BorrowingController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IRequestService _requestService;
        private readonly UserManager<Entities.Concreate.Member> _userManager;
        private readonly IMapper _mapper;
        public BorrowingController(IMapper mapper, IBookService bookService, UserManager<Entities.Concreate.Member> userManager, IRequestService requestService)
        {
            _bookService = bookService;
            _mapper = mapper;
            _requestService = requestService;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index(string s, int page = 1)
        {
            TempData["Active"] = "borrowing";

            int toplamSayfa;

            var db_books = _bookService.GetIndexPageBooks(out toplamSayfa, s, page);

            ViewBag.aktifSayfa = page;

            ViewBag.toplamSayfa = toplamSayfa;

            ViewBag.aranan = s;

            List<BookListWithAuthorDto> bookList = new List<BookListWithAuthorDto>();

            foreach (var db_book in db_books)
            {
                var book = new BookListWithAuthorDto
                {
                    Id = db_book.Book.Id,
                    Name = db_book.Book.Name,
                    Picture = db_book.Book.Picture,
                    PageNumber = db_book.Book.PageNumber,
                    PublishedTime = db_book.Book.PublishedTime,
                    ShortDescription = db_book.Book.ShortDescription,
                    Author = db_book.Book.Author,
                    AuthorId = db_book.Book.AuthorId
                };

                bookList.Add(book);
            }

            ViewBag.Books = bookList;

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> SelectedBook(int bookId)
        {
            TempData["Active"] = "borrowing";

            var db_chosenBook = await _bookService.GetBooksWithAllByIdAsync(bookId);

            var chosenBook = new BookListWithAllDto()
            {
                Id = db_chosenBook.Id,
                Name = db_chosenBook.Name,
                Picture = db_chosenBook.Picture,
                PageNumber = db_chosenBook.PageNumber,
                PublishedTime = db_chosenBook.PublishedTime,
                LongDescription = db_chosenBook.LongDescription,
                Author = db_chosenBook.Author,
                AuthorId = db_chosenBook.AuthorId,
                BaseCategory = db_chosenBook.BaseCategory,
                BaseCategoryId = db_chosenBook.BaseCategory.Id,
                SubCategory = db_chosenBook.SubCategory,
                SubCategoryId = db_chosenBook.SubCategory.Id
            };

            return View(chosenBook);
        }


        [HttpPost]
        public async Task<IActionResult> SelectedBook(string bookId)
        {
            TempData["Active"] = "borrowing";

            var member = _userManager.FindByNameAsync(User.Identity.Name).Result;

            var admins = await _userManager.GetUsersInRoleAsync("Admin");

            var chosenBook = await _bookService.FindByIdAsync(Convert.ToInt32(bookId));

            var request = new RequestAddDto()
            {
                WantedBookId = chosenBook.Id,
                PosterMemberId = member.Id,
                ReceiverMemberId = 8,//admin id
                Description = $"{member.FullName} isimli üye {chosenBook.Name} isimli kitabı ödünç almak istiyor.",
                State = true, // okunmamış
            };


            await _requestService.AddAsync(_mapper.Map<RequestAddDto, Request>(request));

            return RedirectToAction("Index", "Borrowing");
        }

    }
}
