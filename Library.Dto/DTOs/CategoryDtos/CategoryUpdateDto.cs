using Library.DTO.Interfaces;
using Library.Entities.Concreate;
using System.Collections.Generic;

namespace Library.DTO.DTOs.CategoryDtos
{
    public class CategoryUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCategory> SubCategories { get; set; }


    }
}
