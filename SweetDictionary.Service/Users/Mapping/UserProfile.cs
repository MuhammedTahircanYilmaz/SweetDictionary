using AutoMapper;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Users.Dtos.Response;

namespace SweetDictionary.Service.Users.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserResponseDto>();
    }
}
