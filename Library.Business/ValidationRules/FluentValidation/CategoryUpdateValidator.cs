using FluentValidation;
using Library.DTO.DTOs.CategoryDtos;

namespace Library.Business.ValidationRules.FluentValidation
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Kategori adı girilmesi gerekiyor");
        }
    }
}
