using Library.DTO.Interfaces;
using Library.Entities.Concreate;

namespace Library.DTO.DTOs.RequestDtos
{
    public class RequestListDto : IDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }

        public int ReceiverMemberId { get; set; }

        public int PosterMemberId { get; set; }
        public Member PosterMember { get; set; }

        public int WantedBookId { get; set; }
        public Book WantedBook { get; set; }

    }
}
