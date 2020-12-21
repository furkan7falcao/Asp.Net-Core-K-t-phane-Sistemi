using OurProject.LibrarySystem.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurProject.LibrarySystem.DTO.DTOs.AuthorDtos
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
