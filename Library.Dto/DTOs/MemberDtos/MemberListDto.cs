using Library.DTO.Interfaces;

namespace Library.DTO.DTOs.MemberDtos
{
    public class MemberListDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Picture { get; set; }

    }
}
