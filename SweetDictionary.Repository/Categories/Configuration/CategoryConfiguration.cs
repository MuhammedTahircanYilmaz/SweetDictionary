using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionary.Models.Categories.Entities;

namespace SweetDictionary.Repository.Categories.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("Category_Id");
        builder.Property(c => c.CreationTime).HasColumnName("Creation_Time");
        builder.Property(c => c.UpdateTime).HasColumnName("Update_Time");
        builder.Property(c => c.Name).HasColumnName("Category_Name");

        builder.HasMany(x => x.Posts).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);

        builder.Navigation(x => x.Posts).AutoInclude();
    }
}
