using FluentValidation;
using Library.DTO.DTOs.CategoryDtos;

namespace Library.Business.ValidationRules.FluentValidation
{
    public class CategoryAddValidator : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Kategori adı girilmesi gerekiyor");
        }
    }
}
