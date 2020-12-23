using Library.DTO.Interfaces;

namespace Library.DTO.DTOs.MemberDtos
{
    public class MemberSignInDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
