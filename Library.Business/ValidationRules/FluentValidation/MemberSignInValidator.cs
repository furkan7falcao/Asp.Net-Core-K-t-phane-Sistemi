using FluentValidation;
using Library.DTO.DTOs.MemberDtos;

namespace Library.Business.ValidationRules.FluentValidation
{
    public class MemberSignInValidator : AbstractValidator<MemberSignInDto>
    {
        public MemberSignInValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı Adı alanı boş geçilemez");

            RuleFor(I => I.Password).NotNull().WithMessage("Parola alanı boş geçilemez");

        }
             
    }
}
