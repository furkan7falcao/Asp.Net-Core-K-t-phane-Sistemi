using Library.DTO.Interfaces;
using Library.Entities.Concreate;

namespace Library.DTO.DTOs.RequestDtos
{
    public class RequestAddDto : IDto
    {
        public string Description { get; set; }
        public bool State { get; set; }

        public int ReceiverMemberId { get; set; }

        public int PosterMemberId { get; set; }
        public Member PosterMember { get; set; }

        public int WantedBookId { get; set; }
        public Book WantedBook { get; set; }

    }
}
