using Library.DTO.Interfaces;

namespace Library.DTO.DTOs.SubCategoryDtos
{
    public class SubCategoryListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
