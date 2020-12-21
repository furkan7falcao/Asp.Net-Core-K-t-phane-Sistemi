using OurProject.LibrarySystem.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
