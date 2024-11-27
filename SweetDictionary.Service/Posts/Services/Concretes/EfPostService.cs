using AutoMapper;
using Core.Entities;
using Core.Exceptions.Business;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts.Dtos.Requests;
using SweetDictionary.Models.Posts.Dtos.Response;
using SweetDictionary.Repository.Posts.Repositories.Abstract;
using SweetDictionary.Service.CacheServices;
using SweetDictionary.Service.Constants;
using SweetDictionary.Service.Posts.Rules;
using SweetDictionary.Service.Posts.Services.Abstracts;

namespace SweetDictionary.Service.Posts.Services.Concretes;

public class EfPostService(IPostRepository postRepository, IMapper mapper, PostBusinessRules businessRules, PostCacheService cache) : IPostService
{

    public async Task<ReturnModel<NoData>> Add(CreatePostRequestDto dto, string userId)
    {
        Post createdPost = mapper.Map<Post>(dto);
        createdPost.Id = Guid.NewGuid();
        createdPost.AuthorId = userId;

        postRepository.Add(createdPost);
        return ReturnModel<NoData>.ReturnModelOfSuccess(null, 204, Messages.PostAddedMessage);
    }

    public ReturnModel<NoData> Update(UpdatePostRequestDto dto, string userId)
    {

        businessRules.PostIsPresent(dto.Id);

        Post post = postRepository.GetById(dto.Id);

        CheckUserMatches(post.AuthorId, userId);

        post.Title = dto.Title;
        post.Content = dto.Content;

        postRepository.Update(post);

        return ReturnModel<NoData>.ReturnModelOfSuccess(null, 204, Messages.PostAddedMessage);

    }

    public ReturnModel<NoData> Delete(Guid id, string userId)
    {

        businessRules.PostIsPresent(id);

        Post? post = postRepository.GetById(id);

        CheckUserMatches(post.AuthorId, userId);

        postRepository.Delete(post);

        return ReturnModel<NoData>.ReturnModelOfSuccess(null, 204, Messages.PostDeletedMessage);

    }

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
        List<Post> posts = postRepository.GetAll();
        List<PostResponseDto> responses = mapper.Map<List<PostResponseDto>>(posts);

        return ReturnModel<List<PostResponseDto>>.ReturnModelOfSuccess(responses, 200);

    }

    public ReturnModel<PostResponseDto> GetById(Guid id)
    {

        businessRules.PostIsPresent(id);

        Post post = postRepository.GetById( id);
        var response = mapper.Map<PostResponseDto>(post);

        return ReturnModel<PostResponseDto>.ReturnModelOfSuccess(response, 200);

    }

    public ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id)
    {

        var posts = postRepository.GetAll(x => x.CategoryId == id);
        var response = mapper.Map<List<PostResponseDto>>(posts);
        return ReturnModel<List<PostResponseDto>>.ReturnModelOfSuccess(response, 200);

    }

    public ReturnModel<List<PostResponseDto>> GetAllByAuthorId(string authorid)
    {

        var posts = postRepository.GetAll(x => x.AuthorId == authorid);
        var response = mapper.Map<List<PostResponseDto>>(posts);
        return ReturnModel<List<PostResponseDto>>.ReturnModelOfSuccess(response, 200);

    }

    public ReturnModel<List<PostResponseDto>> GetAllByTitleHas(string text)
    {

        var posts = postRepository.GetAll(x => x.Title.Contains(text));
        var response = mapper.Map<List<PostResponseDto>>(posts);
        return ReturnModel<List<PostResponseDto>>.ReturnModelOfSuccess(response, 200);

    }

    private void CheckUserMatches(string userId, string IdToBeChecked)
    {
        if (!(userId == IdToBeChecked))
        {
            throw new BusinessException("The ToDo does not belong to the user!");
        }
    }
}
