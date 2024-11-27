using AutoMapper;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts.Dtos.Requests;
using SweetDictionary.Models.Posts.Dtos.Response;

namespace SweetDictionary.Service.Posts.Mapping;

public class PostProfile : Profile
{
    public PostProfile() 
    {
        CreateMap<CreatePostRequestDto, Post>();
        CreateMap<UpdatePostRequestDto, Post>();
        CreateMap<Post, PostResponseDto>();
    }
}
