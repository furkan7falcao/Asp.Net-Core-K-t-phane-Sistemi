using FluentValidation;
using Library.DTO.DTOs.BookDtos;

namespace Library.Business.ValidationRules.FluentValidation
{
    public class BookAddValidator : AbstractValidator<BookAddDto>
    {
        public BookAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Kitap adı girilmesi gerekiyor");
            RuleFor(I => I.PageNumber).NotEmpty().WithMessage("Sayfa Sayısı girilmesi gerekiyor");
            RuleFor(I => I.ShortDescription).NotNull().WithMessage("Kısa Açıklama girilmesi gerekiyor");
            RuleFor(I => I.LongDescription).NotNull().WithMessage("Uzun Açıklama girilmesi gerekiyor");
            RuleFor(I => I.BaseCategoryId).NotEqual(-1).WithMessage("Ana Kategori seçilmesi gerekiyor");
            RuleFor(I => I.SubCategoryId).NotEqual(-1).WithMessage("Alt Kategori seçilmesi gerekiyor");
            RuleFor(I => I.AuthorId).NotEqual(-1).WithMessage("Yazar seçilmesi gerekiyor");
        }
    }
}
