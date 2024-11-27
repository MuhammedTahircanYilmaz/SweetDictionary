using Core.Repository;
using SweetDictionary.Models.Categories.Entities;

namespace SweetDictionary.Repository.Categories.Repositories.Abstract;

public interface ICategoryRepository : IRepository<Category, int>
{
}

