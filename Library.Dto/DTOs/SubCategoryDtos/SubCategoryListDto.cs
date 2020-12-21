using OurProject.LibrarySystem.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurProject.LibrarySystem.DTO.DTOs.SubCategoryDtos
{
    public class SubCategoryListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
