using Core.Entities;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Models.Comments.Entities;

public sealed class Comment : Entity<Guid>
{
    public string Content { get; set; }
    public Guid PostId { get; set; } // The Id of the Post to which the Comment belongs
    public Post Post { get; set; }
    public string UserId { get; set; } // The Id of the User who has made the Comment
    public User User { get; set; }
}
