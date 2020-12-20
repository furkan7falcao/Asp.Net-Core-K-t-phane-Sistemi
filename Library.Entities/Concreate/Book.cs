using Library.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities.Concreate
{
    public class Book : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public DateTime PublishedTime { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int Count { get; set; }
        public string Picture { get; set; }


        public int BaseCategoryId { get; set; }
        public Category BaseCategory { get; set; }

        public int? SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public List<Request> Requests { get; set; }

    }
}
