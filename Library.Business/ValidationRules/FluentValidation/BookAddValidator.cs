using FluentValidation;
using Library.DTO.DTOs.BookDtos;

namespace Library.Business.ValidationRules.FluentValidation
{
    public class BookAddValidator : AbstractValidator<BookAddDto>
    {
        public BookAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Kitap adı girilmesi gerekiyor");
            RuleFor(I => I.PageNumber).NotNull().WithMessage("Sayfa Sayısı girilmesi gerekiyor");
            RuleFor(I => I.ShortDescription).NotNull().WithMessage("Kısa Açıklama girilmesi gerekiyor");
            RuleFor(I => I.LongDescription).NotNull().WithMessage("Uzun Açıklama girilmesi gerekiyor");
            
        }
    }
}
