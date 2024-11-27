using AutoMapper;
using Core.Entities;
using SweetDictionary.Models.Categories.Dtos.Requests;
using SweetDictionary.Models.Categories.Dtos.Response;
using SweetDictionary.Models.Categories.Entities;
using SweetDictionary.Repository.Categories.Repositories.Abstract;
using SweetDictionary.Service.Categories.Rules;
using SweetDictionary.Service.Categories.Services.Abstracts;
using SweetDictionary.Service.Constants;

namespace SweetDictionary.Service.Categories.Services.Concretes;

public class EfCategoryService(ICategoryRepository _categoryRepository, IMapper _mapper, CategoryBusinessRules _businessRules) : ICategoryService
{
    public ReturnModel<NoData> Add(AddCategoryRequestDto dto)
    {
        Category createdCategory = _mapper.Map<Category>(dto);

        _categoryRepository.Add(createdCategory);

        return ReturnModel<NoData>.ReturnModelOfSuccess(null, 201, Messages.CategoryAddedMessage);

    }

    public ReturnModel<NoData> Update(UpdateCategoryRequestDto dto)
    {
        _businessRules.CategoryIsPresent(dto.Id);

        Category category = _categoryRepository.GetById(dto.Id);

        category.Name = dto.Name;
        _categoryRepository.Update(category);

        return ReturnModel<NoData>.ReturnModelOfSuccess(null, 200, Messages.CategoryUpdatedMessage);

    }

    public ReturnModel<NoData> Delete(int id)
    {
        _businessRules.CategoryIsPresent(id);

        Category category = _categoryRepository.GetById(id);
        _categoryRepository.Delete(category);

        return ReturnModel<NoData>.ReturnModelOfSuccess(null, 204, Messages.CategoryDeletedMessage);
    
    }

    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        var categories = _categoryRepository.GetAll();

        var response = _mapper.Map<List<CategoryResponseDto>>(categories);
        return ReturnModel<List<CategoryResponseDto>>.ReturnModelOfSuccess(response, 200);

    }

    public ReturnModel<CategoryResponseDto> GetById(int id)
    {

        _businessRules.CategoryIsPresent(id);

        Category category = _categoryRepository.GetById(id);

        var response = _mapper.Map<CategoryResponseDto>(category);
        return ReturnModel<CategoryResponseDto>.ReturnModelOfSuccess(response, 200);

    }
}
