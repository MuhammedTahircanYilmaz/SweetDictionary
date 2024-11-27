using Core.Repository;
using SweetDictionary.Models.Comments.Entities;
using SweetDictionary.Repository.Comments.Repositories.Abstract;
using SweetDictionary.Repository.Contexts;

namespace SweetDictionary.Repository.Comments.Repositories.Concrete;

public class EfCommentRepository : EfRepositoryBase<BaseDbContext, Comment, Guid>, ICommentRepository
{
    public EfCommentRepository(BaseDbContext context) : base(context)
    {
    }
}
