using FluentValidation;
using Library.DTO.DTOs.MemberDtos;

namespace Library.Business.ValidationRules.FluentValidation
{
    public class MemberListValidator : AbstractValidator<MemberListDto>
    {
        public MemberListValidator()
        {
            RuleFor(I => I.FullName).NotNull().WithMessage("İsim alanı boş geçilemez");

        }
    }
}
