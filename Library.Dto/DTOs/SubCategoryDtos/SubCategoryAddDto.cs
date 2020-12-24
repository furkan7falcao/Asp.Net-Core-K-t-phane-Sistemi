using Library.DTO.Interfaces;
using Library.Entities.Concreate;

namespace Library.DTO.DTOs.SubCategoryDtos
{
    public class SubCategoryAddDto : IDto
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
