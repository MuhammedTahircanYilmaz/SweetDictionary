using Core.Entities;
using SweetDictionary.Models.Categories.Dtos.Requests;
using SweetDictionary.Models.Categories.Dtos.Response;

namespace SweetDictionary.Service.Categories.Services.Abstracts;

public interface ICategoryService
{

    // Summary:
    //      Sends the Add request for a new Category to the Repository
    //
    // Parameters:
    //   dto:
    //      A dto with necessary fields to create a category
    //
    // Returns:
    //      A ReturnModel of CategoryResponseDto
    //
    // Throws:
    //      BusinessException

    ReturnModel<NoData> Add(AddCategoryRequestDto dto);


    // Summary:
    //      Gets the Update request dto, and after necessary checks, sends the request to the repository layer
    //      
    // Parameters:
    //   dto:
    //      A dto which carries the properties which are going to be updated
    //
    // Returns:
    //      A ReturnModel of CategoryResponseDto
    //     
    // Throws:
    //      NotFoundException
    //      BusinessException

    ReturnModel<NoData> Update(UpdateCategoryRequestDto dto);


    // Summary:
    //
    // Parameters:
    //
    // Returns:
    //
    // Throws:
    //
    // Remarks:

    ReturnModel<NoData> Delete(int id);


    // Summary:
    //
    // Parameters:
    //
    // Returns:
    //
    // Throws:
    //
    // Remarks:

    ReturnModel<List<CategoryResponseDto>> GetAll();


    // Summary:
    //
    // Parameters:
    //
    // Returns:
    //
    // Throws:
    //
    // Remarks:

    ReturnModel<CategoryResponseDto> GetById(int id);
}
