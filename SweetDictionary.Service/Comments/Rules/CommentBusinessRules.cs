using Core.Exceptions.NotFound;
using SweetDictionary.Repository.Comments.Repositories.Abstract;

namespace SweetDictionary.Service.Comments.Rules;

public class CommentBusinessRules(ICommentRepository _commentRepository)
{

    public void CommentIsPresent(Guid id)
    {
        var comment = _commentRepository.GetById(id);
        if (comment is null)
        {
            throw new NotFoundException("The Comment does not exist");
        }
    }
}
