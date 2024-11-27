using Core.Exceptions.NotFound;
using SweetDictionary.Repository.Posts.Repositories.Abstract;
using SweetDictionary.Service.Constants;

namespace SweetDictionary.Service.Posts.Rules;

public class PostBusinessRules(IPostRepository _postRepository)
{
    public void PostIsPresent(Guid id)
    {
        var post = _postRepository.GetById(id);
        if (post is null)
        {
            throw new NotFoundException(Messages.PostIsNotPresentMessage(id));
        }
    }
}
