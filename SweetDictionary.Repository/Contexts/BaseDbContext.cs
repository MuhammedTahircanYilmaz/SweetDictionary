using Microsoft.EntityFrameworkCore;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Repository.Contexts;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions opt) : base(opt)
    {
    }

    public DbSet<Post> Posts { get; set; }
}
