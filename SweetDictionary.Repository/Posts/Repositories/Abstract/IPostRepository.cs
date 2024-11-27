using Core.Repository;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Repository.Posts.Repositories.Abstract;

public interface IPostRepository : IRepository<Post, Guid>
{
}
