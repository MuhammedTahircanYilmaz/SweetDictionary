
using Core.Entities;
using SweetDictionary.Models.Categories.Entities;
using SweetDictionary.Models.Comments.Entities;

namespace SweetDictionary.Models.Entities;

public sealed class Post : Entity<Guid>
{
    public string Title { get; set; }  
    public string Content { get; set; }

    public string AuthorId { get; set; } // The Id of the user who has created the post
    public User Author { get; set; }

    public int CategoryId { get; set; } // The Id of the Category to which the post belongs
    public Category Category { get; set; }

    public List<Comment> Comments { get; set; }
}
