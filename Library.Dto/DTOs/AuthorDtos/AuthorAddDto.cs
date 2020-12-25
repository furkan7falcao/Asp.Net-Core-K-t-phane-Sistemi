using Library.DTO.Interfaces;
using System;

namespace Library.DTO.DTOs.AuthorDtos
{
    public class AuthorAddDto : IDto
    {
        public string FullName { get; set; }
        public string Nation { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}
