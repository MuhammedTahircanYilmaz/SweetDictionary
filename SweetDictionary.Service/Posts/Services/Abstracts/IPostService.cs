using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts.Dtos.Requests;
using SweetDictionary.Models.Posts.Dtos.Response;

namespace SweetDictionary.Service.Posts.Services.Abstracts;

public interface IPostService
{
    Task<ReturnModel<NoData>> Add(CreatePostRequestDto dto, string userId);
    ReturnModel<NoData> Update(UpdatePostRequestDto dto, string userId);
    ReturnModel<NoData> Delete(Guid id, string userId);
    ReturnModel<List<PostResponseDto>> GetAll();
    ReturnModel<PostResponseDto> GetById(Guid id);
    ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id);
    ReturnModel<List<PostResponseDto>> GetAllByAuthorId(string id);
    ReturnModel<List<PostResponseDto>> GetAllByTitleHas(string text);
}
