using Core.Repository;
using SweetDictionary.Models.Categories.Entities;
using SweetDictionary.Repository.Categories.Repositories.Abstract;
using SweetDictionary.Repository.Contexts;

namespace SweetDictionary.Repository.Categories.Repositories.Concrete;

public class EfCategoryRepository : EfRepositoryBase<BaseDbContext, Category, int>, ICategoryRepository
{
    public EfCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}
