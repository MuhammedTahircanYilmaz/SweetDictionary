using FluentValidation;
using SweetDictionary.Models.Categories.Dtos.Requests;

namespace SweetDictionary.Service.Categories.Validations;

public class CreateCategoryValidation : AbstractValidator<AddCategoryRequestDto>
{
    public CreateCategoryValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("The category name cannot be empty!");
    }
}
