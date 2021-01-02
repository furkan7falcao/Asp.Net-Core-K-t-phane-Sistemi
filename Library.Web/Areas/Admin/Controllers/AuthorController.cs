using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Library.Business.Interfaces;
using Library.DTO.DTOs.AuthorDtos;
using Library.Entities.Concreate;
using Library.DTO.DTOs.BookDtos;

namespace Library.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorService authorService, IBookService bookService, IMapper mapper)
        {
            _authorService = authorService;
            _bookService = bookService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetBookOfAuthors(int authorId)
        {
            TempData["Active"] = "author";

            var db_Books = await _bookService.GetBooksOfAuthorAsync(authorId);

            var BookList = new List<BookListDto>();

            foreach (var db_Book in db_Books)
            {
                var book = new BookListDto();

                book.Id = db_Book.Id;
                book.Name = db_Book.Name;
                book.PageNumber = db_Book.PageNumber;
                book.PublishedTime = db_Book.PublishedTime;
                book.Picture = db_Book.Picture;

                BookList.Add(book);
            }

            var jsonAuthors = JsonConvert.SerializeObject(BookList);

            return Json(jsonAuthors);
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "author";

            var db_authors = await _authorService.GetAuthorsWithBooksAsync();

            var authorList = new List<AuthorListDto>();

            foreach (var authors in db_authors)
            {
                var author = new AuthorListDto();

                author.Id = authors.Id;
                author.FullName = authors.FullName;
                author.BirthDate = authors.BirthDate;
                author.Gender = authors.Gender;
                author.Nation = authors.Nation;
                author.Books = authors.Books;

                authorList.Add(author);
            }

            return View(authorList);
        }


        [HttpGet]
        public IActionResult Add()
        {
            TempData["Active"] = "author";

            return View(new AuthorAddDto());
        }


        [HttpPost]
        public async Task<IActionResult> Add(AuthorAddDto model)
        {
            TempData["Active"] = "author";

            if (ModelState.IsValid)
            {
                await _authorService.AddAsync(_mapper.Map<AuthorAddDto, Author>(model));

                return RedirectToAction("Index", "Author");
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            TempData["Active"] = "author";

            var author = await _authorService.FindByIdAsync(id);

            var updatedAuthor = new AuthorUpdateDto
            {
                   Id = author.Id,
                   BirthDate = author.BirthDate,
                   FullName = author.FullName,
                   Gender = author.Gender,
                   Nation = author.Nation
            };

            return View(updatedAuthor);
        }


        [HttpPost]
        public async Task<IActionResult> Update(AuthorUpdateDto model)
        {
            TempData["Active"] = "author";

            if (ModelState.IsValid)
            {
                await _authorService.UpdateAsync(_mapper.Map<AuthorUpdateDto, Author>(model));

                return RedirectToAction("Index", "Author");
            }

            return View(model);
        }





    }
}

