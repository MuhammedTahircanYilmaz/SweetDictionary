using Core.Entities;
using Microsoft.AspNetCore.Identity;
using SweetDictionary.Models.Comments.Entities;

namespace SweetDictionary.Models.Entities;

public sealed class User : IdentityUser
{
    public DateTime? BirthDate { get; set; } // The Birth Date of the user, to restrict access to portions of the dictionary, if there is a need
    public List<Post>? Posts { get; set; } // The list of the Posts the User has created
    public List<Comment>? Comments { get; set; } // The list of Comments which the User has created on Posts 
}