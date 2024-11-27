using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SweetDictionary.Models.Categories.Entities;
using SweetDictionary.Models.Comments.Entities;
using SweetDictionary.Models.Entities;
using System.Reflection;

namespace SweetDictionary.Repository.Contexts;

public class BaseDbContext : IdentityDbContext<User, IdentityRole, string>
{
    public BaseDbContext(DbContextOptions opt) : base(opt)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Post> Posts { get; set; }  // The property DbSet<TEntity> causes a table of TEntity to be created in the database
                                            // And allows the manipulation of the said table
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
