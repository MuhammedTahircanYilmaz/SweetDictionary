using AutoMapper;
using SweetDictionary.Models.Categories.Dtos.Requests;
using SweetDictionary.Models.Categories.Dtos.Response;
using SweetDictionary.Models.Categories.Entities;

namespace SweetDictionary.Service.Categories.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {

            CreateMap<AddCategoryRequestDto, Category>();
            CreateMap<Category, CategoryResponseDto>();
        }
    }

}
