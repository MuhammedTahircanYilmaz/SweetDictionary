namespace SweetDictionary.Models.Categories.Dtos.Requests;

public sealed record AddCategoryRequestDto
{
    public string Name { get; init; }
}
