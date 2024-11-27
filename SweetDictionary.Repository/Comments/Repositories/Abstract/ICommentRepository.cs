using Core.Repository;
using SweetDictionary.Models.Comments.Entities;

namespace SweetDictionary.Repository.Comments.Repositories.Abstract;

public interface ICommentRepository : IRepository<Comment, Guid>
{
}
