using OurProject.LibrarySystem.DTO.Interfaces;
using OurProject.LibrarySystem.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurProject.LibrarySystem.DTO.DTOs.LendingDtos
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
