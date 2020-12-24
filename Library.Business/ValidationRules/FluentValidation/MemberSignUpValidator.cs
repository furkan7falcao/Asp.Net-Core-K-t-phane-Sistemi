using FluentValidation;
using Library.DTO.DTOs.MemberDtos;

namespace Library.Business.ValidationRules.FluentValidation
{
    public class MemberSignUpValidator : AbstractValidator<MemberSignUpDto>
    {
        public MemberSignUpValidator()
        {
            RuleFor(I => I.FullName).NotNull().WithMessage("İsim alanı boş geçilemez");
            RuleFor(I => I.Password).NotNull().WithMessage("Parola alanı boş geçilemez");
            RuleFor(I => I.ConfirmPassword).Equal(I => I.Password).WithMessage("Parola alanları eşleşmiyor");
            RuleFor(I => I.BirthYear).NotNull().WithMessage("Doğum tarihi alanı boş geçilemez");
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı Adı alanı boş geçilemez");
            RuleFor(I => I.PhoneNumber).NotNull().WithMessage("Telefon numarası alanı boş geçilemez");
            RuleFor(I => I.Email).EmailAddress().NotNull().WithMessage("Email alanı boş geçilemez");

        }

    }
}
