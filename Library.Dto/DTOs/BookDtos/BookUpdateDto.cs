using Library.DTO.Interfaces;
using System;

namespace Library.DTO.DTOs.BookDtos
{
    public class BookUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int PageNumber { get; set; }
        public DateTime PublishedTime { get; set; }
        public int Count { get; set; }
        public string Picture { get; set; }


        



    }
}
