using FluentValidation;
using Library.DTO.DTOs.SubCategoryDtos;

namespace Library.Business.ValidationRules.FluentValidation
{
    public class SubCategoryAddValidator : AbstractValidator<SubCategoryAddDto>
    {
        public SubCategoryAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Kategori adı girilmesi gerekiyor");
        }
    }
}
