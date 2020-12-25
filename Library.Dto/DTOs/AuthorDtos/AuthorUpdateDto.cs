using Library.DTO.Interfaces;
using System;

namespace Library.DTO.DTOs.AuthorDtos
{
    public class AuthorUpdateDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nation { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}
