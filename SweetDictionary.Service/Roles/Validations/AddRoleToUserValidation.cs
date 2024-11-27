using FluentValidation;
using SweetDictionary.Models.Roles.Dtos;

namespace SweetDictionary.Service.Roles.Validations;

public class AddRoleToUserValidation : AbstractValidator<AddRoleToUserRequestDto>
{
    public AddRoleToUserValidation()
    {
        RuleFor(r => r.RoleName).NotEmpty().WithMessage("The Role name cannot be empty");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("The UserId cannot be empty");
    }
}
