using OurProject.LibrarySystem.DTO.Interfaces;
using OurProject.LibrarySystem.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurProject.LibrarySystem.DTO.DTOs.RequestDtos
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
