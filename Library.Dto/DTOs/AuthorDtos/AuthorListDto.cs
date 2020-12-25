using Library.DTO.Interfaces;
using Library.Entities.Concreate;
using System;
using System.Collections.Generic;

namespace Library.DTO.DTOs.AuthorDtos
{
    public class AuthorListDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nation { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }

        public List<Book> Books { get; set; }

    }
}
