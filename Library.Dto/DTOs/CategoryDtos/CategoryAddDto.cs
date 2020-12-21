using OurProject.LibrarySystem.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurProject.LibrarySystem.DTO.DTOs.CategoryDtos
{
    public class CategoryAddDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
