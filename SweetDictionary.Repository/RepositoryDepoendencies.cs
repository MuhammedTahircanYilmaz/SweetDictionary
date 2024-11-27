using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SweetDictionary.Repository.Categories.Repositories.Abstract;
using SweetDictionary.Repository.Categories.Repositories.Concrete;
using SweetDictionary.Repository.Comments.Repositories.Abstract;
using SweetDictionary.Repository.Comments.Repositories.Concrete;
using SweetDictionary.Repository.Contexts;
using SweetDictionary.Repository.Posts.Repositories.Abstract;
using SweetDictionary.Repository.Posts.Repositories.Concrete;

namespace SweetDictionary.Repository;

public static class RepositoryDepoendencies
{
    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPostRepository, EfPostRepository>();
        services.AddScoped<ICategoryRepository, EfCategoryRepository>();
        services.AddScoped<ICommentRepository, EfCommentRepository>();
        services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        return services;
    }
}
