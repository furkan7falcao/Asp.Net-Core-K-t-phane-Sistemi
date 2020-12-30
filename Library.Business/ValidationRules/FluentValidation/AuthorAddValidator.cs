using FluentValidation;
using Library.DTO.DTOs.AuthorDtos;

namespace Library.Business.ValidationRules.FluentValidation
{
    public class AuthorAddValidator : AbstractValidator<AuthorAddDto>
    {
        public AuthorAddValidator()
        {
            RuleFor(I => I.FullName).NotNull().WithMessage("Yazar adı girilmesi gerekiyor");
            RuleFor(I => I.Nation).NotNull().WithMessage("Ulus bilgisi girilmesi gerekiyor");
            RuleFor(I => I.Gender).NotNull().WithMessage("Cinsiyet bilgisi girilmesi gerekiyor");
            RuleFor(I => I.BirthDate).NotNull().WithMessage("Doğum Tarihi girilmesi gerekiyor");
        }
    }
}
