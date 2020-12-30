using FluentValidation;
using Library.DTO.DTOs.SubCategoryDtos;

namespace Library.Business.ValidationRules.FluentValidation
{
    public class SubCategoryUpdateValidator : AbstractValidator<SubCategoryUpdateDto>
    {
        public SubCategoryUpdateValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Kategori adı girilmesi gerekiyor");
        }
    }
}
