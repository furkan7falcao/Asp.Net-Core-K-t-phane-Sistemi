using Library.DTO.Interfaces;
using Library.Entities.Concreate;

namespace Library.DTO.DTOs.SubCategoryDtos
{
    public class SubCategoryUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
