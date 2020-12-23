using Library.DTO.Interfaces;

namespace Library.DTO.DTOs.MemberDtos
{
    public class MemberListDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Picture { get; set; }

    }
}
