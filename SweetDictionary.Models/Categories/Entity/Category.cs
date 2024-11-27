using Core.Entities;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Models.Categories.Entities;

public class Category : Entity<int>
{
    public string Name { get; set; }
    public List<Post> Posts { get; set; } // The list of Posts belonging to the Category
}
