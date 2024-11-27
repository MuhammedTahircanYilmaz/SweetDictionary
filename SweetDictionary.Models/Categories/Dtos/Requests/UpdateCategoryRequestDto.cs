namespace SweetDictionary.Models.Categories.Dtos.Requests;

public sealed record UpdateCategoryRequestDto
{
    public int Id { get; init; }
    public string Name { get; init; }
}
