using OurProject.LibrarySystem.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurProject.LibrarySystem.DTO.DTOs.MemberDtos
{
    public class MemberSignUpDto : IDto
    {
        public string UserName { get; set; } //Tc
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthYear { get; set; }
        public string Picture { get; set; }

    }
}
