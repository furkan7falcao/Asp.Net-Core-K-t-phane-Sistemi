using OurProject.LibrarySystem.DTO.Interfaces;
using OurProject.LibrarySystem.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurProject.LibrarySystem.DTO.DTOs.BookDtos
{
    public class BookListWithAuthorDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public DateTime PublishedTime { get; set; }
        public string ShortDescription { get; set; }

        public int Count { get; set; }
        public string Picture { get; set; }


        public int AuthorId { get; set; }
        public Author Author { get; set; }




    }
}
