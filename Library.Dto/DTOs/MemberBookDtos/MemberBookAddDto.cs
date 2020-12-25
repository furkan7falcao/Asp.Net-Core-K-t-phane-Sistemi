using Library.DTO.Interfaces;
using Library.Entities.Concreate;

namespace Library.DTO.DTOs.MemberBookDtos
{
    public class MemberBookAddDto : IDto
    {
        public bool isRead { get; set; }

        public int? MemberId { get; set; }
        public Member Member { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
