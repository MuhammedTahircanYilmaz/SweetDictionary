using SweetDictionary.Models.Entities;

namespace SweetDictionary.Service.Constants;

public static class Messages
{
    public const string CategoryAddedMessage = "The Category has been added.";
    public const string CategoryUpdatedMessage = "The Category has been updated.";
    public const string CategoryDeletedMessage = "The Category has been deleted.";

    public const string UserRegisteredMessage = "The User has been registered";
    public const string UserLoggedInMessage = "The User has logged in";
    public const string UserUpdatedMessage = "The User has been updated";
    public const string UserDeletedMessage = "The User has been deleted";

    public const string PostAddedMessage = "Post has been added";
    public const string PostUpdatedMessage = "Post has been Updated";
    public const string PostDeletedMessage = "Post has been deleted";

    public static string CategoryIsNotPresentMessage(int id)
    {
        return $"The Category with the Id : {id} could not be found.";
    }

    public static string PostIsNotPresentMessage(Guid id)
    {
        return $"The Post with the Id : {id} could not be found";
    }
}
