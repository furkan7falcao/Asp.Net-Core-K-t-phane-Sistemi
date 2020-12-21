using OurProject.LibrarySystem.DTO.Interfaces;
using OurProject.LibrarySystem.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurProject.LibrarySystem.DTO.DTOs.SubCategoryDtos
{
    public class SubCategoryAddDto : IDto
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
