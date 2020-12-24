using Library.DTO.Interfaces;

namespace Library.DTO.DTOs.CategoryDtos
{
    public class CategoryAddDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
