using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionary.Models.Comments.Entities;

namespace SweetDictionary.Repository.Comments.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments").HasKey(x => x.Id);
        builder.Property(c => c.Id).HasColumnName("Comment_Id");
        builder.Property(x => x.Content).HasColumnName("Content");
        builder.Property(c => c.CreationTime).HasColumnName("Creation_Time");
        builder.Property(c => c.UpdateTime).HasColumnName("Update_Time");
        builder.Property(x => x.PostId).HasColumnName("Post_Id");
        builder.Property(x => x.UserId).HasColumnName("User_Id");

        builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);

        builder.Navigation(x => x.User).AutoInclude();
        builder.Navigation(x => x.Post).AutoInclude();
    }
}