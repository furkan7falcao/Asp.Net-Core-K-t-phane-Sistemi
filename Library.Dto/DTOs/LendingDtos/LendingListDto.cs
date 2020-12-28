using Library.DTO.Interfaces;
using Library.Entities.Concreate;

namespace Library.DTO.DTOs.LendingDtos
{
    public class LendingListDto : IDto
    {
        public int Id { get; set; }

        public int PosterMemberId { get; set; }
        public Member PosterMember { get; set; }

        public int WantedBookId { get; set; }
        public Book WantedBook { get; set; }


    }
}
