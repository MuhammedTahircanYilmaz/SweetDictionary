using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Repository.Posts.Configuration;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("Post_Id");
        builder.Property(c => c.CreationTime).HasColumnName("Creation_Time");
        builder.Property(c => c.UpdateTime).HasColumnName("Update_Time");
        builder.Property(c => c.Title).HasColumnName("Title");
        builder.Property(c => c.Content).HasColumnName("Content");
        builder.Property(c => c.AuthorId).HasColumnName("Author_Id");
        builder.Property(c => c.CategoryId).HasColumnName("Category_Id");

        builder.HasOne(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Author).WithMany(x => x.Posts).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(x => x.Comments).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction); ;

        builder.Navigation(x => x.Category).AutoInclude();
        builder.Navigation(x => x.Author).AutoInclude();
        builder.Navigation(x => x.Comments).AutoInclude();
    }
}
