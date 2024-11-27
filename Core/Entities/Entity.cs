using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public abstract class Entity<TId> // The Base class for any entity other than the User. Requires the input of the type of the Id the entity has
{
    public TId Id { get; set; } // The Identifier for any given object of any class
    public DateTime CreationTime { get; set; } // The time when the object is first initiated on the database.
    public DateTime? UpdateTime { get; set; } // The time when the object is last updated on the database
}
