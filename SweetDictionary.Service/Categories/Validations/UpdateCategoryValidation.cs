using FluentValidation;
using SweetDictionary.Models.Categories.Dtos.Requests;

namespace SweetDictionary.Service.Categories.Validations;

public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryRequestDto>
{
    public UpdateCategoryValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("The category name cannot be empty");
        RuleFor(x => x.Id).NotNull().WithMessage("The category id cannot be null");
    }
}

