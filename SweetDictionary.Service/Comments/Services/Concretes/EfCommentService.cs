using AutoMapper;
using Core.Entities;
using Core.Exceptions.Business;
using Core.Exceptions.NotFound;
using SweetDictionary.Models.Comments.Dtos.Requests;
using SweetDictionary.Models.Comments.Dtos.Response;
using SweetDictionary.Models.Comments.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository.Comments.Repositories.Abstract;
using SweetDictionary.Service.Comments.Rules;
using SweetDictionary.Service.Comments.Services.Abstracts;

namespace SweetDictionary.Service.Comments.Services.Concretes;

public class EfCommentService(ICommentRepository commentRepository, IMapper mapper, CommentBusinessRules businessRules) : ICommentService
{
    public ReturnModel<NoData> Add(AddCommentRequestDto dto, string userId)
    {
        Comment createdComment = mapper.Map<Comment>(dto);
        createdComment.UserId = userId;

        Comment comment = commentRepository.Add(createdComment);

        return ReturnModel<NoData>.ReturnModelOfSuccess(null, 200, "Comment Has Been Added");
    }

    public ReturnModel<NoData> Update(UpdateCommentRequestDto dto, string userId)
    {
        businessRules.CommentIsPresent(dto.Id);
        
        Comment comment = commentRepository.GetById(dto.Id);

        CheckUserMatches(userId, comment.UserId);

        comment.Content = dto.Content;
        
        commentRepository.Update(comment);

        return ReturnModel<NoData>.ReturnModelOfSuccess(null, 200, "Comment has been updated");
    }

    public ReturnModel<NoData> Delete(Guid id, string userId)
    {

        businessRules.CommentIsPresent(id);

        Comment comment = commentRepository.GetById(id);
        CheckUserMatches(userId, comment.UserId);

        commentRepository.Delete(comment);

        return ReturnModel<NoData>.ReturnModelOfSuccess(null, 204, "Comment has been deleted");

    }

    public ReturnModel<List<CommentResponseDto>> GetAll()
    {
        var comments = commentRepository.GetAll();
        var response = mapper.Map<List<CommentResponseDto>>(comments);
        return ReturnModel<List<CommentResponseDto>>.ReturnModelOfSuccess(response, 200);
    }

    public ReturnModel<CommentResponseDto> GetById(Guid id)
    {

        businessRules.CommentIsPresent(id);
        Comment comment = commentRepository.GetById(id);

        var response = mapper.Map<CommentResponseDto>(comment);
        return ReturnModel<CommentResponseDto>.ReturnModelOfSuccess(response, 200);

    }

    public ReturnModel<List<CommentResponseDto>> GetAllByUserId(string userId)
    {
        List<Comment> comments = commentRepository.GetAll(x=> x.UserId == userId);

        var response = mapper.Map<List<CommentResponseDto>>(comments);
        return ReturnModel<List<CommentResponseDto>>.ReturnModelOfSuccess(response, 200);

    }

    public ReturnModel<List<CommentResponseDto>> GetAllByPostId(Guid postId)
    {
        List<Comment> comments = commentRepository.GetAll(x => x.PostId == postId);

        var response = mapper.Map<List<CommentResponseDto>>(comments);
        return ReturnModel<List<CommentResponseDto>>.ReturnModelOfSuccess(response, 200);

    }

    private void CheckUserMatches(string userId, string IdToBeChecked)
    {
        if (!(userId == IdToBeChecked))
        {
            throw new BusinessException("The ToDo does not belong to the user!");
        }
    }
}
