using Core.Entities;
using SweetDictionary.Models.Comments.Dtos.Requests;
using SweetDictionary.Models.Comments.Dtos.Response;

namespace SweetDictionary.Service.Comments.Services.Abstracts;

public interface ICommentService
{
    ReturnModel<NoData> Add(AddCommentRequestDto dto, string userId);
    ReturnModel<NoData> Update(UpdateCommentRequestDto dto, string userId);
    ReturnModel<NoData> Delete(Guid id, string userId);
    ReturnModel<List<CommentResponseDto>> GetAll();
    ReturnModel<CommentResponseDto> GetById(Guid id);
    ReturnModel<List<CommentResponseDto>> GetAllByUserId(string userId);
    ReturnModel<List<CommentResponseDto>> GetAllByPostId(Guid postId);


}
