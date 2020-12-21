using OurProject.LibrarySystem.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurProject.LibrarySystem.DTO.DTOs.MemberDtos
{
    public class MemberListDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Picture { get; set; }

    }
}
