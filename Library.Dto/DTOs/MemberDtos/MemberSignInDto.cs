using OurProject.LibrarySystem.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurProject.LibrarySystem.DTO.DTOs.MemberDtos
{
    public class MemberSignInDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
