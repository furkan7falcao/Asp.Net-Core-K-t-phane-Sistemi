using Library.DTO.Interfaces;
using Library.Entities.Concreate;
using System;
using System.Collections.Generic;

namespace Library.DTO.DTOs.BookDtos
{
    public class BookListTakenDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public string LongDescription { get; set; }
        public DateTime PublishedTime { get; set; }
        public string Picture { get; set; }


        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int BaseCategoryId { get; set; }
        public Category BaseCategory { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public List<Request> Requests { get; set; }

    }
}
