using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Library.Business.Interfaces;
using Library.DTO.DTOs.BookDtos;
using Library.DTO.DTOs.MemberBookDtos;
using Library.Entities.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Library.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IAuthorService authorService, ICategoryService categoryService, IMapper mapper)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetBooksOfSubCategories(int SubCategoryId)
        {
            TempData["Active"] = "category";

            var db_Books = await _bookService.GetBooksWithSubCategoryIdAsync(SubCategoryId);

            var BookList = new List<BookListDto>();

            foreach (var db_Book in db_Books)
            {
                var book = new BookListDto();

                book.Id = db_Book.Id;
                book.Name = db_Book.Name;
                book.PageNumber = db_Book.PageNumber;
                book.PublishedTime = db_Book.PublishedTime;
                book.Count = db_Book.Count;

                BookList.Add(book);
            }

            var jsonBooks = JsonConvert.SerializeObject(BookList);

            return Json(jsonBooks);
        }



        [HttpGet]
        public async Task<IActionResult> GetBooksOfBaseCategories(int BaseCategoryId)
        {
            TempData["Active"] = "category";

            var db_Books = await _bookService.GetBooksWithBaseCategoryIdAsync(BaseCategoryId);

            var BookList = new List<BookListDto>();

            foreach (var db_Book in db_Books)
            {
                var book = new BookListDto();

                book.Id = db_Book.Id;
                book.Name = db_Book.Name;
                book.PageNumber = db_Book.PageNumber;
                book.PublishedTime = db_Book.PublishedTime;
                book.Count = db_Book.Count;

                BookList.Add(book);
            }

            var jsonBooks = JsonConvert.SerializeObject(BookList);

            return Json(jsonBooks);
        }




        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "book";

            ViewBag.BaseCategories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");

            var db_books = await _bookService.GetBooksWithAuthorsAsync();

            var bookList = new List<BookListDto>();

            foreach (var books in db_books)
            {
                var book = new BookListDto();

                book.Id = books.Id;
                book.Name = books.Name;
                book.PageNumber = books.PageNumber;
                book.PublishedTime = books.PublishedTime;
                book.Count = books.Count;

                bookList.Add(book);
            }

            return View(bookList);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            TempData["Active"] = "book";

            ViewBag.Authors = new SelectList(await _authorService.GetAllAsync(), "Id", "FullName");

            ViewBag.BaseCategories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");

            return View(new BookAddDto());
        }


        [HttpPost]
        public async Task<IActionResult> Add(BookAddDto model, string SubCategorydrp, IFormFile Picture)
        {
            TempData["Active"] = "book";

            if (ModelState.IsValid)
            {
                var addedBook = new BookAddDto()
                {
                    Name = model.Name,
                    PageNumber = model.PageNumber,
                    PublishedTime = model.PublishedTime,
                    ShortDescription = model.ShortDescription,
                    LongDescription = model.LongDescription,
                    Count = model.Count,
                    AuthorId = model.AuthorId,
                    BaseCategoryId = model.BaseCategoryId,
                    SubCategoryId = Convert.ToInt32(SubCategorydrp),
                };


                if (Picture != null)
                {
                    string uzanti = Path.GetExtension(Picture.FileName);
                    string pictureName = Guid.NewGuid() + uzanti;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + pictureName);


                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await Picture.CopyToAsync(stream);
                    }

                    addedBook.Picture = pictureName;
                }

                await _bookService.AddAsync(_mapper.Map<BookAddDto, Book>(addedBook));

                //---------------------------------------------------------------------

                var addedBookId = (await _bookService.FindByNameAsync(addedBook.Name)).Id; //eklenen kitabın id'si name ile bulunuyor

                var addedMemberBook = new MemberBookAddDto()
                {
                    BookId = addedBookId,
                    MemberId = null,
                    isRead = false                   
                };

                await _bookService.AddToMemberBookTableWithoutMemberAsync(_mapper.Map<MemberBookAddDto,MemberBook>(addedMemberBook));

                //---------------------------------------------------------------------

                return RedirectToAction("Index", "Book");
            }

            return View();
        }



        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            TempData["Active"] = "book";

            var book = await _bookService.FindByIdAsync(id);

            var updatedBook = new BookUpdateDto()
            {
                Id = book.Id,
                Name = book.Name,
                PageNumber = book.PageNumber,
                ShortDescription = book.ShortDescription,
                LongDescription = book.LongDescription,
                PublishedTime = book.PublishedTime,
                Count = book.Count,
                Picture = book.Picture

            };

            return View(updatedBook);
        }


        [HttpPost]
        public async Task<IActionResult> Update(BookUpdateDto model, IFormFile Picture)
        {
            TempData["Active"] = "book";

            if (ModelState.IsValid)
            {
                var updatedBook = new BookUpdateDto()
                {
                    Id = model.Id,
                    Name = model.Name,
                    PageNumber = model.PageNumber,
                    PublishedTime = model.PublishedTime,
                    LongDescription = model.LongDescription,
                    ShortDescription = model.ShortDescription,
                    Count = model.Count,
                    Picture = model.Picture
                };

                await _bookService.UpdateAsync(_mapper.Map<BookUpdateDto, Book>(updatedBook));

                return RedirectToAction("Index", "Book");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            _bookService.RemoveAsync(new Book { Id = id });

            return Json(null);
        }








    }
}
