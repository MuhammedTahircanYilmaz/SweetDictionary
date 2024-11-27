using AutoMapper;
using SweetDictionary.Models.Comments.Dtos.Requests;
using SweetDictionary.Models.Comments.Dtos.Response;
using SweetDictionary.Models.Comments.Entities;

namespace SweetDictionary.Service.Comments.Mapping
{
    public class CommentProfile : Profile
    {
        public CommentProfile() 
        {
            CreateMap<AddCommentRequestDto, Comment>();
            CreateMap<UpdateCommentRequestDto, Comment>();
            CreateMap<Comment, CommentResponseDto>();
        }
    }

}
