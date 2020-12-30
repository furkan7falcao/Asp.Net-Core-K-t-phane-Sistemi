using Library.DTO.Interfaces;
using Library.Entities.Concreate;
using System;

namespace Library.DTO.DTOs.BookDtos
{
    public class BookAddDto : IDto
    {
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public  DateTime PublishedTime { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Picture { get; set; }


        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int BaseCategoryId { get; set; }
        public Category BaseCategory { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

    }
}
