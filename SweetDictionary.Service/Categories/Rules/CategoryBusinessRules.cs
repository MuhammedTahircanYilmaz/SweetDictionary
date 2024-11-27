using Core.Exceptions.NotFound;
using SweetDictionary.Repository.Categories.Repositories.Abstract;
using SweetDictionary.Service.Constants;

namespace SweetDictionary.Service.Categories.Rules;

public class CategoryBusinessRules(ICategoryRepository _categoryRepository)
{
    public virtual bool CategoryIsPresent(int id)
    {
        var category = _categoryRepository.GetById(id);
        if (category is null)
        {
            throw new NotFoundException(Messages.CategoryIsNotPresentMessage(id));
        }
        return true;
    }
}
